    using OfficeOpenXml;
    using OfficeOpenXml.Table;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    public static class ImportExcelReader
    {
        public static List<T> ImportExcelToList<T>(this ExcelWorksheet worksheet) where T : new()
        {
            //DateTime Conversion
            Func<double, DateTime> convertDateTime = new Func<double, DateTime>(excelDate =>
            {
                if (excelDate < 1)
                {
                    throw new ArgumentException("Excel dates cannot be smaller than 0.");
                }
                DateTime dateOfReference = new DateTime(1900, 1, 1);
                if (excelDate > 60d)
                {
                    excelDate = excelDate - 2;
                }
                else
                {
                    excelDate = excelDate - 1;
                }
                return dateOfReference.AddDays(excelDate);
            });
            ExcelTable table = null;
            if (worksheet.Tables.Any())
            {
                table = worksheet.Tables.FirstOrDefault();
            }
            else
            {
                table = worksheet.Tables.Add(worksheet.Dimension, "tbl" + ShortGuid.NewGuid().ToString());
                ExcelAddressBase newaddy = new ExcelAddressBase(table.Address.Start.Row, table.Address.Start.Column, table.Address.End.Row + 1, table.Address.End.Column);
                //Edit the raw XML by searching for all references to the old address
                table.TableXml.InnerXml = table.TableXml.InnerXml.Replace(table.Address.ToString(), newaddy.ToString());
            }
            //Get the cells based on the table address
            List<IGrouping<int, ExcelRangeBase>> groups = table.WorkSheet.Cells[table.Address.Start.Row, table.Address.Start.Column, table.Address.End.Row, table.Address.End.Column]
                .GroupBy(cell => cell.Start.Row)
                .ToList();
            //Assume the second row represents column data types (big assumption!)
            List<Type> types = groups.Skip(1).FirstOrDefault().Select(rcell => rcell.Value.GetType()).ToList();
            //Get the properties of T
            List<PropertyInfo> modelProperties = new T().GetType().GetProperties().ToList();
            //Assume first row has the column names
            var colnames = groups.FirstOrDefault()
                .Select((hcell, idx) => new
                {
                    Name = hcell.Value.ToString(),
                    index = idx
                })
                .Where(o => modelProperties.Select(p => p.Name).Contains(o.Name))
                .ToList();
            //Everything after the header is data
            List<List<object>> rowvalues = groups
                .Skip(1) //Exclude header
                .Select(cg => cg.Select(c => c.Value).ToList()).ToList();
            //Create the collection container
            List<T> collection = new List<T>();
            foreach (List<object> row in rowvalues)
            {
                T tnew = new T();
                foreach (var colname in colnames)
                {
                    //This is the real wrinkle to using reflection - Excel stores all numbers as double including int
                    object val = row[colname.index];
                    Type type = types[colname.index];
                    PropertyInfo prop = modelProperties.FirstOrDefault(p => p.Name == colname.Name);
                    //If it is numeric it is a double since that is how excel stores all numbers
                    if (type == typeof(double))
                    {
                        //Unbox it
                        double unboxedVal = (double)val;
                        //FAR FROM A COMPLETE LIST!!!
                        if (prop.PropertyType == typeof(int))
                        {
                            prop.SetValue(tnew, (int)unboxedVal);
                        }
                        else if (prop.PropertyType == typeof(double))
                        {
                            prop.SetValue(tnew, unboxedVal);
                        }
                        else if (prop.PropertyType == typeof(DateTime))
                        {
                            prop.SetValue(tnew, convertDateTime(unboxedVal));
                        }
                        else if (prop.PropertyType == typeof(string))
                        {
                            prop.SetValue(tnew, val.ToString());
                        }
                        else
                        {
                            throw new NotImplementedException(string.Format("Type '{0}' not implemented yet!", prop.PropertyType.Name));
                        }
                    }
                    else
                    {
                        //Its a string
                        prop.SetValue(tnew, val);
                    }
                }
                collection.Add(tnew);
            }
            return collection;
        }
    }

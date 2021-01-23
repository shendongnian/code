    public static class EPPLusExtensions
    {
        public static readonly Func<double, DateTime> convertDateTime = new Func<double, DateTime>(excelDate =>
        {
            if (excelDate < 1)
                throw new ArgumentException("Excel dates cannot be smaller than 0.");
            var dateOfReference = new DateTime(1900, 1, 1);
            if (excelDate > 60d)
                excelDate = excelDate - 2;
            else
                excelDate = excelDate - 1;
            return dateOfReference.AddDays(excelDate);
        });
        public static IEnumerable<T> ConvertSheetToObjects<T>(this ExcelWorksheet worksheet) where T : new()
        {
            System.Reflection.MemberInfo info = typeof(T);
            object[] attributes = info.GetCustomAttributes(true);
            for (int i = 0; i < attributes.Length; i++)
            {
                System.Console.WriteLine(attributes[i]);
            }
            Func<CustomAttributeData, bool> columnOnly = y => y.AttributeType == typeof(Column);
            var columns = typeof(T)
                    .GetProperties()
                    .Where(x => x.CustomAttributes.Any(columnOnly))
            .Select(p => new
            {
                Property = p,
                Column = p.GetCustomAttributes<Column>().First().ColumnIndex //safe because if where above
            }).ToList();
            //Cells only contains references to cells with actual data
            var groups = worksheet.Cells
                .GroupBy(cell => cell.Start.Row)
                .ToList();
            //Everything after the header is data
            var rowvalues = groups
                .Skip(1) //Exclude header
                .Select(cg => cg.Select(c => c.Value).ToList());
            //Create the collection container
            var collection = rowvalues
                .Select(row =>
                {
                    var tnew = new T();
                    columns.ForEach(col =>
                    {
                        //This is the real wrinkle to using reflection - Excel stores all numbers as double including int
                        
                        var val = col.Column < row.Count ?  row[col.Column] : null;
                        //If it is numeric it is a double since that is how excel stores all numbers
                        if (val == null)
                        {
                            col.Property.SetValue(tnew, val);
                            return;
                        }
                        if (col.Property.PropertyType == typeof(Int32))
                        {
                            col.Property.SetValue(tnew, (int)val);
                            return;
                        }
                        if (col.Property.PropertyType == typeof(double))
                        {
                            var  unboxedVal = (double)val;
                            col.Property.SetValue(tnew, unboxedVal);
                            return;
                        }
                        if (col.Property.PropertyType == typeof(DateTime))
                        {
                            var unboxedVal = (double)val;
                            col.Property.SetValue(tnew, convertDateTime(unboxedVal));
                            return;
                        }
                        //Its a string
                        col.Property.SetValue(tnew, val);
                    });
                    return tnew;
                });
            //Send it back
            return collection;
        }
    }

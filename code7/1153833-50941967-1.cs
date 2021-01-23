    using NPOI.SS.UserModel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Text.RegularExpressions;
    
    namespace GenericExcelExport.ExcelExport
    {
        public class AbstractDataExportBridge : AbstractDataExport
        {
            public AbstractDataExportBridge()
            {
                _headers = new List<string>();
                _type = new List<string>();
            }
    
            public override void WriteData<T>(List<T> exportData)
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
    
                DataTable table = new DataTable();
    
                foreach (PropertyDescriptor prop in properties)
                {
                    var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    _type.Add(type.Name);
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? 
                                      prop.PropertyType);
                    string name = Regex.Replace(prop.Name, "([A-Z])", " $1").Trim(); //space separated 
                                                                               //name by caps for header
                    _headers.Add(name);
                }
    
                foreach (T item in exportData)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    table.Rows.Add(row);
                }
    
                IRow sheetRow = null;
    
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    sheetRow = _sheet.CreateRow(i + 1);
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        ICell Row1 = sheetRow.CreateCell(j);
    
                        string type = _type[j].ToLower();
                        var currentCellValue = table.Rows[i][j];
    
                        if (currentCellValue != null && 
                            !string.IsNullOrEmpty(Convert.ToString(currentCellValue)))
                        {
                            if (type == "string")
                            {
                                Row1.SetCellValue(Convert.ToString(currentCellValue));
                            }
                            else if (type == "int32")
                            {
                                Row1.SetCellValue(Convert.ToInt32(currentCellValue));
                            }
                            else if (type == "double")
                            {
                                Row1.SetCellValue(Convert.ToDouble(currentCellValue));
                            }
                        }
                        else
                        {
                            Row1.SetCellValue(string.Empty);
                        }
                    }
                }
            }
        }
    }

    using System;
    using System.IO;
    using System.Data;
    using System.Collections.Generic;
    using System.Linq;
    using Excel;  // Install Nuget Package ExcelDataReader
    
    public class Program
    {
        public static string[][] ExcelSheetToJaggedArray(string fileName, string sheetName)
        {
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                {
                    var data =
                        excelReader.AsDataSet().Tables
                            .Cast<DataTable>()
                            .FirstOrDefault(sheet => sheet.TableName == sheetName);
    
                    return
                        data.Rows
                            .Cast<DataRow>()
                            .Select(row => 
                                row.ItemArray 
                                    .Select(cell => cell.ToString()).ToArray())
                            .ToArray();
                }
            }
        }
    
        public static void Main()
        {
            // Sample use of ExcelSheetToJaggedArray function
            var fileName = @"C:\SampleInput.xlsx";
            var jaggedArray = ExcelSheetToJaggedArray(fileName, "Sheet1");
    
            foreach (var row in jaggedArray)
            {
                foreach (var cell in row)
                {
                    Console.Write(cell.ToString() + ",");
                }
                Console.WriteLine();
            }
        }
    }

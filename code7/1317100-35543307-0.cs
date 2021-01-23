    using NetOffice.OfficeApi;
    using System;
    
    namespace Office_Doc_Reader
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var wordApp = new NetOffice.WordApi.Application())
                using (var excelApp = new NetOffice.ExcelApi.Application())
                {
                    var doc = wordApp.Documents.Open("C:\\Users\\John\\Desktop\\test.docx");
                    var xls = excelApp.Workbooks.Open("C:\\Users\\John\\Desktop\\test.xlsx");
    
                    var customProperties = (DocumentProperties)doc.CustomDocumentProperties;
    
                    foreach (var property in customProperties)
                    {
                        Console.WriteLine(String.Format("Name: {0}, Value: {1}, Type: {2}", property.Name, property.Value, property.Type));
                    }
    
                    customProperties = (DocumentProperties)xls.CustomDocumentProperties;
    
                    foreach (var property in customProperties)
                    {
                        Console.WriteLine(String.Format("Name: {0}, Value: {1}, Type: {2}", property.Name, property.Value, property.Type));
                    }
                }
    
                Console.ReadKey();
            }
        }
    }

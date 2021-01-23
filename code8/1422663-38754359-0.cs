    using System;
    using System.Linq;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    
    
    
    namespace ConsoleApplication1
    {
        class Program
        {
    
            private static void Main(string[] args)
            {
                var filePath = @"c:\xyz\stack_c_Sharp.xlsx";
                using (var document = SpreadsheetDocument.Open(filePath, false))
                {
                    var workbookPart = document.WorkbookPart;
                    var workbook = workbookPart.Workbook;
    
                    var sheets = workbook.Descendants<Sheet>();
                    foreach (var sheet in sheets)
                    {
                        var worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
                        var sharedStringPart = workbookPart.SharedStringTablePart;
    
                        string text;
                        var rows = worksheetPart.Worksheet.Descendants<Row>();
                        foreach (var row in rows)
                        {
                            Console.WriteLine();
                            int count = row.Elements<Cell>().Count();
    
                            foreach (Cell theCell in row.Elements<Cell>())
                            {
    
                                text = theCell.CellValue.InnerText;
    
                                double d = double.Parse(theCell.InnerText);
                                DateTime conv = DateTime.FromOADate(d).Date;
    
                                Console.Write(text + " ");
                                Console.Write(conv + " ");
    
                            }
                        }
                    }
                    Console.ReadLine();
                }
    
                
            }
        }
    }

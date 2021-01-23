    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                HSSFWorkbook hssfwb;
                using (var file = new FileStream(args[0], FileMode.Open, FileAccess.Read))
                {
                    hssfwb = new HSSFWorkbook(file);
                }
    
                ISheet sheet = hssfwb.GetSheet("Arkusz1");
                for (int row = 0; row <= sheet.LastRowNum; row++)
                {
                    if (sheet.GetRow(row) != null) //null is when the row only contains empty cells 
                    {
                        Console.WriteLine(sheet.GetRow(row).GetCell(0).StringCellValue);
                    }
                }
            }
        }
    }

            int lastColumNum = sheet.GetRow(0).LastCellNum;
            for (int i = 0; i <= lastColumNum; i++)
            {
                sheet.AutoSizeColumn(i);
                GC.Collect();
            }
            using (var fileData = new FileStream(@"D:\Contatti.xlsx", FileMode.Create))
            {
                wb.Write(fileData);
            }

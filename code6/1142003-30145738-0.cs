        using (ExcelPackage package = new ExcelPackage(new FileInfo(@"C:\temp\superscriptExample.xlsx")))
        {
            var ws = package.Workbook.Worksheets.First();
               
               
            ExcelRichTextCollection richText = ws.Cells[1, 1].RichText;
            string htmlString = "";
            foreach (var part in richText)
            {
                if (part.VerticalAlign == ExcelVerticalAlignmentFont.Superscript)
                {
                    htmlString += "<sup>" + part.Text + "</sup>";
                }
                else
                {
                    htmlString += part.Text;
                }
            }
               
        } 

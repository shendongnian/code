        static void Main(string[] args)
        {
            Dictionary<string, Color> dictionaryTextToColour = new Dictionary<string, Color>();
            var fInfo = new FileInfo(@"C:\Temp\sample.xlsx");
            using (var package = new ExcelPackage(fInfo))
            {
                
                var a1 = package.Workbook.Worksheets.First().Cells[1, 1];
                
                if (a1.IsRichText)
                {
                    var richText = a1.RichText;
                    dictionaryTextToColour = richText 
                        .ToDictionary(rt => rt.Text, rt => rt.Color); //NOT recommended to use a dictionary here
                }
            }
            foreach (var substring in dictionaryTextToColour.Keys)
            {
                Console.WriteLine(substring + ": " + dictionaryTextToColour[substring]);
            }
        }

        // Add references for
        // System.IO.Compression
        // System.IO.Compression.FileSystem
        private static List<string> GetCellsWithFormulaInSheet(string xlsxFileName, int sheetNumber)
        {
            using (var zip = System.IO.Compression.ZipFile.OpenRead(xlsxFileName))
            {
                var list = new List<string>();
                var entry = zip.Entries.FirstOrDefault(e => e.FullName == "xl/calcChain.xml");
                if (entry == null)
                    return list;
                var xdoc = XDocument.Load(entry.Open());
                XNamespace ns = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
                return xdoc.Root.Elements(ns + "c")
                    .Select(x => new { Cell = x.Attribute("r").Value, Sheet = int.Parse(x.Attribute("i").Value) })
                    .Where(x => x.Sheet == sheetNumber)
                    .Select(x => x.Cell)
                    .ToList();
            }
        }

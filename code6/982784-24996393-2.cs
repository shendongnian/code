    var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.pdf");
    using (var fs = new FileStream(testFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
        using (var doc = new Document()) {
            using (var writer = PdfWriter.GetInstance(doc, fs)) {
                doc.Open();
                var t = new PdfPTable(1);
                //Implement our class
                t.TableEvent = new SplitTableWatcher();
                //Add a single header row
                t.HeaderRows = 1;
                t.AddCell("Header");
                //Create 100 test cells
                for (var i = 1; i < 100; i++) {
                    t.AddCell(i.ToString());
                }
                doc.Add(t);
                doc.Close();
            }
        }
    }

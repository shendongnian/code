    public void MergeFiles(string[] strFiles, String strFileresult) {
        using( var document = new Document()) {
            using (var copy = new PdfCopy(document, new FileStream(strFileresult, FileMode.Create))) {
                document.Open();
                foreach( var file in strFiles) {
                    using (var reader = new PdfReader(file)) {
                        copy.AddDocument(reader);
                    }
                }
                document.Close();
            }
        }
    }

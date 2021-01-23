    public class ClientOfPdfObject<T> where T: PdfObject
    {
        public List<T> GetItems()
        {
            List<PdfObject> list = GetList();
            var result = new List<T>();
            foreach (var pdfObject in list)
            {
                if (typeof (T) == pdfObject.GetType())
                    result.Add((T) pdfObject);
            }
            return result;
        }
        //Get PdfObjects somewhere (ex. Db)
        private List<PdfObject> GetList()
        {
            var list = new List<PdfObject>
            {
                new PdfImage(),
                new PdfImage(),
                new PdfImage(),
                new PdfText(),
                new PdfText(),
                new PdfText(),
                new PdfText()
            };
            
            return list;
        }
    }
    static void main()
    {
            var text = new ClientOfPdfObject<PdfText>();
            //contains 4 itmes (PdfText)
            var pdfTexts = text.GetItems();
            var image = new ClientOfPdfObject<PdfImage>();
            //contains 3 items (PdfImage)
            var pdfImages = image.GetItems();
    }

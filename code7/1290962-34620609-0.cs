    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class PdfReaderPage
    {        
        public int Foo;
    }
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class AccessibleFromVBA
    {
        public Microsoft.VisualBasic.Collection PdfReaderPages()
        {
            /* 1. make a List of PdfReaderPage elements */
            var csharp_list = new List<PdfReaderPage>()
            { 
                new PdfReaderPage() {Foo=1},
                new PdfReaderPage() {Foo=2},
                new PdfReaderPage() {Foo=3}
            };
            /* 2. convert it into a vb collection */
            var vb_coll = new Microsoft.VisualBasic.Collection();
            csharp_list.ForEach(x => vb_coll.Add(x));
            /* 3. deliver it */
            return vb_coll;
        }
    }

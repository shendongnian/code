    public class IAFT
    {
        public struct FileDetail
        {
            public string FileType;
            public int FileNumber;
        }
    }
    
    public class MyForm
    {
       
        public MyForm()
        {
            IAFT.FileDetail fd = new IAFT.FileDetail();
        }
    }

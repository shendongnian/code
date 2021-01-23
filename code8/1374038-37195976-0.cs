    public class IAFT
    {
        fileDetail FileDetail = new fileDetail();
    }
    public class fileDetail
    {
        public string FileType;
        public int FileNumber;
    }
    public class MyForm
    {
       MyForm()
       {
           IAFT.FileDetail.FileType = "test";
           //IAFT.FileDetail
       }
    }

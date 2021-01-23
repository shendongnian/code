    public abstract class AdminViewModel
    {
        public MyOtherDTO InitData { get; set; }
    }
    public class PageViewModel : AdminViewModel
    {
        public MyDTO PageData { get; set; }
    }

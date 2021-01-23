    public class MainViewModel
    {
        public MainViewModel()
        {
            Form1 = new Form1ViewModel();
            Form2 = new Form2ViewModel();
            ...
        }
        public Form1ViewModel Form1 { get; set; }
        public Form2ViewModel Form2 { get; set; }
        ...
    }

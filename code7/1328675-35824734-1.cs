    public partial class DataContextSample : Window
    {
        public string HeaderText { set; get; }
        private Source source { get; set; }
        public DataContextSample()
        {
            ...
            source = new Source();
            TextBlock2.DataContext = source;
            ...
        }
        ...
    }

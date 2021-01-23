    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Model = new Model();
        }
        public Model Model { get; set; }
    }
    public class Model
    {
        public Model()
        {
            Txt0 = 42;
            Txt1 = 99;
        }
        public int? Txt0 { get; set; }
        public int? Txt1 { get; set; }
    }

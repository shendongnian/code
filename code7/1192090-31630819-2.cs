    public class Part
    {
        public int PN { get; set; }
        public String PName { get; set; }
        public String Color { get; set; }
        public int Weight { get; set; }
        public String City { get; set; }
    }
    public partial class MainWindow : Window
    {
        private List<Part> _parts;
        public MainWindow()
        {
            InitializeComponent();
            _parts.Add(new Part() { PN = 1, PName = "Nut", Color = "Red", Weight = 12, City = "London" });
            _parts.Add(new Part() { PN = 2, PName = "Bolt", Color = "Green", Weight = 17, City = "Paris" });
            _parts.Add(new Part() { PN = 3, PName = "Screw", Color = "Blue", Weight = 17, City = "Rome" });
            _parts.Add(new Part() { PN = 4, PName = "Screw", Color = "Red", Weight = 14, City = "London" });
            _parts.Add(new Part() { PN = 5, PName = "Cam", Color = "Blue", Weight = 12, City = "Paris" });
            _parts.Add(new Part() { PN = 6, PName = "Cog", Color = "Red", Weight = 19, City = "London" });
        }
        private void SomeMethod()
        {
            string colorChoice = "Blue";
            IEnumerable<string> partResults = _parts
                .Where(clr => String.Equals(clr.Color, colorChoice))
                .Select(part => String.Format("{0}", part.PName));
        }
    }

    public partial class MainWindow
    {
        public IList<Programme> pgr { get; }
        public MainWindow()
        {
            pgr = new List<Programme>
                {
                    new Programme("First", "FirstDate", "FirstChaine"),
                    new Programme("Second", "SecondDate", "SecondChaine"),
                    new Programme("Third", "ThirdDate", "ThirdChaine"),
                };
            InitializeComponent();
        }
        public class Programme
        {
            // No changes
        }
    }

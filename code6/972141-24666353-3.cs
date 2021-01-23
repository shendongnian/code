    public partial class MainWindow : Window
        {
            private System.Random random;
            private string TestData = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum";
            private List<string> words;
            private int maxword;
            private int index;
    
            private FlowDocument doc;
            private Paragraph paragraph;
            
            public MainWindow()
            {
                InitializeComponent();
    
                DataContext = doc = new FlowDocument();
    
                doc.Blocks.Add(paragraph = new Paragraph());
    
                Task.Factory.StartNew(AddDataLoop);
            }
    
            private void AddDataLoop()
            {
                random = new Random();
                words = TestData.Split(' ').ToList();
                maxword = words.Count - 1;
    
                while (true)
                {
                    Thread.Sleep(10);
                    Dispatcher.BeginInvoke((Action) (AddRandomEntry));
                }
            }
    
            private void AddRandomEntry()
            {
                var run = new Run(string.Join(" ", Enumerable.Range(5, random.Next(10, 50))
                                                             .Select(x => words[random.Next(0, maxword)])));
    
                var isBold = random.Next(1, 10) > 5;
    
                if (isBold)
                    paragraph.Inlines.Add(new Bold(run));
                else
                    paragraph.Inlines.Add(run);
    
                paragraph.Inlines.Add(new LineBreak());
            }
        }

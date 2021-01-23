        public MainWindow()
        {
            InitializeComponent();
            var result = "";
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                result += (line);
            }
            MessageBox.Show(result);
        }

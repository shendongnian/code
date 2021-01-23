          public Form1()
        {
            InitializeComponent();
                 DirectoryInfo dir = new DirectoryInfo(".\\Notes\\");
            FileInfo[] files = dir.GetFiles("*.txt");
            foreach (FileInfo file in files)
            {
                listBox1.Items.Add(file);
            }
        }
 

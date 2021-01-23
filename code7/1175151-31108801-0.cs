    public partial class Form1 : Form
    {
        const string DirName = "Mydir";
        const string RootFolder = @"c:\test";
        public Form1()
        {
            CreateDirectories(0, 5, 5, RootFolder);
            InitializeComponent();
        }
        public void CreateDirectories(int currentDepth, int maxDepth, int iterations, string root)
        {
            if (currentDepth > maxDepth)
            {
                return;
            }
            for (var i = 0; i < iterations; i++)
            {
                var currentDirName = Path.Combine(root, DirName + i.ToString());
                Directory.CreateDirectory(currentDirName);
                CreateDirectories(currentDepth + 1, maxDepth, iterations, currentDirName);
            }
        }
    }

        public ProfileManager(String Path)
        {
            InitializeComponent();
            PopulateListBox(@"C:\Users\ProfileList.txt");
            
            string[] testedfiles = System.IO.Directory.GetFiles(Path,"*.vcxproj");       // Display the list of .vcxproj projects to Build
            foreach (string file in testedfiles)
                 
                lb_AllProjects.Items.Add(System.IO.Path.GetFileName(file));
               
        }
         
         private void PopulateListBox(string path)
         {
            
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                this.lb_ProfileList.Items.Add(line.Split(' ')[0]);
                
            
            } 
         }

    private void MyApps(object sender, EventArgs e)
        {
            String currentUser = Environment.UserName.ToString();
            string[] directories = Directory.GetDirectories(@"C:\Users\" + currentUser + @"\desktop\My Applications");
            foreach (string dir in directories)
            {
                string[] subdir = Directory.GetDirectories(dir);
                MenuItem mi=new MenuItem(dir);
                foreach (string sub in subdir)
                {
                    mi.MenuItems.Add(sub); 
                }
                
                this.trayMenu.MenuItems.Add(mi);
                string[] files = Directory.GetFiles(dir);
                foreach (string file in files)
                {
                    this.trayMenu.MenuItems.Add(file);
                }
            }
        }

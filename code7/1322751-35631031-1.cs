            BindingList<string> paths;
    
            public MainWindow()
            {
                InitializeComponent();
    
                paths = new BindingList<string>();
                paths.Add(@"Transfer");
                paths.Add(@"Transfer\Classified");
                paths.Add(@"Transfer\Keys");
                paths.Add(@"Transfer\Container");
                paths.Add(@"Transfer");
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                foreach (string dirCreate in paths)
                {
                    try
                    {
                        if (!Directory.Exists(String.Concat(txtFolderPath.Text, "\\", dirCreate)))
                        {
                            Directory.CreateDirectory(String.Concat(txtFolderPath.Text, "\\", dirCreate));
                        }
                        else
                        {
                            MessageBox.Show(String.Format("{0} already exists", dirCreate));
                        }
    
                    }
                    catch (UnauthorizedAccessException msg)
                    {
                        MessageBox.Show(msg.Message);
                    }
                }
            }

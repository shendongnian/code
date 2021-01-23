    private void DoSomethingAsync() {
    
                ProgressBarVisibility = Visibility.Visible;
                Task.Factory.StartNew(() => { PerformCDDetection(); }).ContinueWith(t => { ProgressBarVisibility = Visibility.Collapsed; });
            }
    
    
    
             public ICommand ImportFilePathCommand
            {
                get
                {
                    return new RelayCommand(() => { DoSomethingAsync(); });
                }
    
            }
              private void PerformCDDetection()
            {
                //Gets all the drives 
                DriveInfo[] allDrives = DriveInfo.GetDrives();
    
                //checks if any CD-Rom exists in the drives
                var cdRomExists = allDrives.Any(x => x.DriveType == DriveType.CDRom);
    
                // Get all the cd roms
                var cdRoms = allDrives.Where(x => x.DriveType == DriveType.CDRom && allDrives.Any(y => y.IsReady));
    
                if (cdRomExists.Equals(true))
                {
                    // Loop through the cd roms collection
                    foreach(var cdRom in cdRoms)
                    {
                        Console.WriteLine("Drive {0}", cdRom.Name);
                        Console.WriteLine("  File type: {0}", cdRom.DriveType);
    
                        if (cdRom.IsReady == true)
                        {
                            if (cdRom.DriveType == DriveType.CDRom)
                            {
                                DirectoryInfo di = new DirectoryInfo(cdRom.RootDirectory.Name);
    
                                var file = di.GetFiles("*.xml", SearchOption.AllDirectories).FirstOrDefault();
    
                                if (file == null)
                                {
                                    Console.WriteLine("failed to find file"); 
                                }
                                else
                                {
                                    foreach (FileInfo info in di.GetFiles("*.xml", SearchOption.AllDirectories))
                                    {
                                        Debug.Print(info.FullName);
                                        break;      // only looking for the first one
                                    }
                                    break;
                                }
                            }
                        }
                        else if (cdRom.IsReady == false)
                        {
                            Console.WriteLine("Cd-ROM is not ready");
                            break;
                        }
    
                    }
                }
                else
                {
                    Console.WriteLine("CD ROM is not detected");
    
                }
    
            } 

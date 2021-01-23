      get
                {
                  string dirName = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                  string pathName = String.Empty;
                  DirectoryInfo d = new DirectoryInfo("TradeBotData");
                  if (!d.Exists) {
                    if (d.Parent.Name == "Plugins") {
                      d.Create();
                      pathName = d.FullName;
                    }
                  } else {
                    if (d.Parent.Name == "Plugins") {
                      pathName = d.FullName;
                    } else {
                      Console.WriteLine("Data path Fallback!!!");
                      pathName = System.IO.Path.Combine(dirName, @"\TradeBotData");
                      System.IO.Directory.CreateDirectory(pathName);
                      Console.WriteLine("Created Save Folder At: {0} :", pathName);
        
                    }
                  }
        
                  return pathName;
                }

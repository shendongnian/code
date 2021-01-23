    string tmpDir = "C:\tmp\mytmp";
    using(SvnClient svn = new SvnClient())
    {
         List<Uri> toProcess = new List<Uri>();
         svn.List(new Uri("http://my-repos/trunk"), new SvnListArgs() { Depth=Infinity }),
         delegate(object sender, SvnListEventArgs e)
         {
             if (e.Path.EndsWith(".rdl", StringComparison.OrdinalIgnoreCase))
                 toProcess.Add(e.Uri);
         });
         foreach(Uri i in toProcess)
         {
             Console.WriteLine("Processing {0}", i);
             Directory.Delete(tmpDir, true);
             // Create a sparse checkout with just one file (see svnbook.org)
             string name = SvnTools.GetFileName(i);
             string fileName = Path.Join(tmpDir, name)
             svn.CheckOut(new Uri(toProcess, "./"), new SvnCheckOutArgs { Depth=Empty });
             svn.Update(fileName);
             ProcessFile(fileName); // Read file and save in same location
             // Note that the following commit is a no-op if the file wasn't
             // changed, so you don't have to check for that yourself
             svn.Commit(fileName, new SvnCommitArgs { LogMessage="Processed" });
        }
    }

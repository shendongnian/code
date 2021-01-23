    		public void Main()
		{
            // putting in a wrapper to load assembly "manually"
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }
        static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.Contains("<name of lost reference>"))
            {
                string path = @"<your location here>";
                return System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(path, "<the errant dll"));
            }
            return null;
        }

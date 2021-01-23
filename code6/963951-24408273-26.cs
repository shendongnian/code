        public IList<string> StandardAssemblyReferences
        {
            get
            {
                return new string[]
                {
                    //If this host searches standard paths and the GAC,
                    //we can specify the assembly name like this.
                    //---------------------------------------------------------
                    //"System"
                    //Because this host only resolves assemblies from the 
                    //fully qualified path and name of the assembly,
                    //this is a quick way to get the code to give us the
                    //fully qualified path and name of the System assembly.
                    //---------------------------------------------------------
                    typeof(System.Uri).Assembly.Location,
                    typeof(System.Linq.Enumerable).Assembly.Location
                };
            }
        }

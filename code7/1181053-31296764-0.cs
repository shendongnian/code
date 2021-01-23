        public string GetInitialFolder(DTE dte)
        {
            if (!dte.Solution.IsOpen)
                return null;
            return System.IO.Path.GetDirectoryName(dte.Solution.FullName);
        }

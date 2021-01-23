    public Class1
    {
        public IEnumerable<string> ProjectList()
        {
            try
            {
                var srv = new ProjectService(ApiToken);
                var obj = srv.List();
                // Return the list to the caller
                return obj;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
        }
    }

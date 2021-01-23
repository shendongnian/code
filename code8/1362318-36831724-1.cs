        public EmptyResult ExportExcel(DataTable test)
        {
            var grid = new GridView();
            grid.DataSource = test;
            grid.DataBind();
           ... your existing code 
            return new EmptyResult();
        }

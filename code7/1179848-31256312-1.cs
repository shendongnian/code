    public class LoadData
    {
        private static readonly  string _projectName;
        public string ProjectName
        {
            get { return LoadData._projectName; }
        }
        public void GetProjectName()
        {
             //Retrieving data from db
            _projectName= dt.Rows[0]["projectname"].ToString();
        }
    }

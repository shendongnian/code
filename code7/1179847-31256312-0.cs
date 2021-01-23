    public class LoadData
    {
        public static readonly  string _projectName;
        public void GetProjectName()
        {
             //Retrieving data from db
            _projectName= dt.Rows[0]["projectname"].ToString();
        }
    }

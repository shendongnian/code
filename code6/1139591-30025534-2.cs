    public class DatasourceForm : Form
    {
        public myDataBase DataBase
        {
            get
            {
                return myDataBaseFactory.Current;
            }
        }
    }

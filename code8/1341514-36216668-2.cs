    public class FormA
    {
       public FormA()
       {
       }
     
       public object GetDataSource()
       {
          return datagrid1.DataSource.ToObject();
       }
    }
    public class B
    {
        private A _formA;
        public B(A formA)
        {
           _formA = formA;
        }
        private void GetDataSourceFromA()
        {
            object dataSource = _formA.GetDataSource();
        }
    }

    namespace WpfApplication1
    {
        class ModelClass
        {
            private DataAccessClass _data;
            public ModelClass()
            {
                _data = new DataAccessClass();
            }
            public List<EmployeeList> GetDataSet()
            {
                return _data.GetEmployeeInfo();
            }
        }
    }

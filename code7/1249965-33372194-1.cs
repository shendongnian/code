    class DataContainer
    {
        public int I {get; set;}
        public string S {get;set;}
        public MyClass Mc {get;set;}
        public DataGridViewColumn Col {get;set;}
    }
    void MyMethod(int option)
    {
        DataContainer container;    
    
        if(option == 0)
        {
            Helper(new DataContainer(m_SomeInt, ...));
        }
        else if(option == 1)
        {
            Helper(new DataContainer(m_SomeOtherInt, ...));
        }
        else
        {
             throw new ArgumentOutOfRangeException(nameof(option));
        }
    }
    void Helper(DataContainer container)
    {
            container.I = 5;
            container.S = "Changed String";
            .....
    }

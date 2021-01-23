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
            container = m_SomeContainer;
        }
        else if(option == 1)
        {
            container = m_SomeOtherContainer;
        }
        else
        {
             throw new ArgumentOutOfRangeException(nameof(option));
        }
    
        container.I = 5;
        container.S = "Changed String";
        .....
    
    }

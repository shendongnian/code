    namespace Homework_Excercise
    {
        class Person
        {
            public delegate void bdateHandler(string message);
            public event bdateHandler happybday;
            public void RaiseEvent(string message)
            {
                if (happybday != null)
                {
                    happybday(message)
                }
            }
            private int _age;
    
            public int age
            {
                get 
                { 
                     return _age; 
                } 
                set 
                { 
                     _age = value;
                     if (/*condition with age*/)
                     {
                         RaiseEvent(Name);
                     } 
                }
            }
            private string Name;
    
            public string name
            {
                get { return Name; }
                set { Name = value; }
            }
        }
    }

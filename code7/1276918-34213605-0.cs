    public class GradeBook
        {
            protected List<float> grades;
    
            public event NameChangedDelegate NameChanged;
    
            private string _name;
    
           void someMethod() {
              _name = "blah";
           }
    
           //more code
        }

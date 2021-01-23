     public class Person
        {
        
            private string _Nome;
            private string _Nascimento;
        
            public string Nome { get { return _Nome; } set { _Nome = value; } }
            public string Nascimento { get { return _Nascimento; } set { _Nascimento= value; } }
          
            public Person()
            {
                
            }
    
            public Person(string Nome, DateTime Nascimento)
            {
                _Nome = Nome;
                _Nascimento = Nascimento.ToString();
            }
        
        }

    namespace ConsoleApplication1
    {
        public interface ISsnFormater
        {
            string Format(string input);
        }
    
        public class ClientOneFormater : ISsnFormater
        {
            public string Format(string input)
            {
                throw new NotImplementedException();
            }
        }
    
        public class ClientTwoFormater : ISsnFormater
        {
            public string Format(string input)
            {
                throw new NotImplementedException();
            }
        }
    
        public class FormaterFactory
        {
            public ISsnFormater GetFormaterFor(string customerName)
            {
                switch (customerName)
                {
                    case "One":
                        return new ClientOneFormater();
    
                    case "Two":
                        return new ClientTwoFormater();
                }
    
                throw  new IndexOutOfRangeException();
            }
        }
    
    }

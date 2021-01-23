    public class StringBuilderService : IStringBuilderService
    {
        private StringBuilder _actualStringBuilder;
        public StringBuilder S
        {
         get { return _actualStringBuilder; }
        }  
   
        public StringBuilderService() // you could also take in a parameter if you wish to initialize the variable
        {
         _actualStringBuilder = new StringBuilder();
        } 
      
        public string Append(string line)
        {
            return _actualStringBuilder.Append(line); 
        }
    
        public override ToString()
        {
         return _actualStringBuilder.ToString();
        }
    }

    public interface IStringBuilderService
    {
      IStringBuilderService Append(string line); // mimic the StringBuilder Append signature
      StringBuilder S { get; }
     }
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
      
        public IStringBuilderService Append(string line)
        {
            _actualStringBuilder.Append(line);
            return this; 
        }
    
        public override string ToString()
        {
         return _actualStringBuilder.ToString();
        }
    }

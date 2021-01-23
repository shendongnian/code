    public class MyDocument
    {
        private XDocument the_document = null;
    
        public string Property1
        {
            get
            {
                return this.the_document... //put DOM manipulation here
            }
            set
            {
               if(value == null)
                   throw new ArgumentNullException(nameof(value));
               this.document... = value //setter DOM manipulation here
            }
        }
    }

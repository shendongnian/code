    public class Sample
    {
        private string someText;
    
        // This Property Stores or modifies SomeText
        public string SomeText 
        {
            get { return this.someText; }        
            set { this.someText = value; }
        }
    
        // Method that does sth. (writes sometext to a given File)
        public void WriteSomeTextToFile(string File)
        {
             // ...
        }
    }

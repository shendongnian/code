    class Program
    {
        static void Main(string[] args)
        {    
            new Program().AddStringToCollection();
        }             
    
        private void AddStringToCollection()
        {
            var summary = new string[] {"A", "B", "C", "", "D"};
    
            var deviceScreenshot = new List<string>();
            var fiddlerScreenshot = new List<string>();
    
            AppendExceptWhiteSpace(deviceScreenshot, summary[3]);
            AppendExceptWhiteSpace(fiddlerScreenshot, summary[4]);
        }
    
        //move to a resource file if possible
        const string NotFoundText = "Screenshot not found";
    
        //in a utility class this could also be an extension method
        private void AppendExceptWhiteSpace(List<string> list, string value)
        {
            //not sure if you want empty strings, otherwise change back to IsNullOrEmpty
            string text = string.IsNullOrWhiteSpace(value) 
                    ? NotFoundText 
                    : value;
    
            list.Add(text);
        }    
    }

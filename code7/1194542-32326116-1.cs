     static void Main(string[] args)
        {
            //IEnumerable x = new object[0];
            //var result2 = x.Select(_ => _.Text); 
            //Compile time Error "Enumerable" does not contain a definition for  'Select' and no extension method
           // because IEnumerable is not a generic class
     
            IEnumerable<object> x = new object[0];
            var result2 = x.Select(_ => _.Text);        
        }

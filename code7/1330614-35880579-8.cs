     using System.Reflection;
     class Person {
        public string Name {get; set;}
        public int Age  {get; set;}
        public string[] NickNames  {get; set;}
        public Person(){}
        public void LoadInfo(string textFile)
        {
                //assign the values to a new instance. 
                Person p = new Person();
                p = JsonConvert.DeserializeObject<Person>(textFile);
                //get all the properties of the person class.
                var properties = this.GetType().GetProperties();
                //loop through the properties.
                foreach (var property in properties)
                {
                    //Get the type (Person)
                    Type type = this.GetType();
                    //set the value for the property.
                    type.GetProperty(property.Name).SetValue(this, type.GetProperty(property.Name).GetValue(p));
                }
    
         }
    }

    [DataContract]
    public class Person {
        [DataMember]
        public string Name {get; set;}
        [DataMember]
        public int Age {get; set;}
        [DataMember]
        public string[] NickNames {get; set;}
    
        public Person(){}
    }
    
    public class PersonController
    {
        public Person LoadInfo(string textFile){
            
            var p = JsonConvert.DeserializeObject<Person>(textFile);
    
            //return an instance of person, mapped from the textfile.
            return p;
        }
    }

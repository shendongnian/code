    jsonInput = "{ 
                  'PERSON' : {
                             'FNAME': 'John'; 
                             'LNAME': 'Doe', 
                             'CITY': 'Vancuver'
                            } 
                 }";
    Public class Person{
         public Person(string json,string city,string country){
                JObject jObject = JObject.Parse(json);
                JToken jPerson = jObject["PERSON"];
                FNAME= (string) jPerson ["FNAME"];
                LNAME= (string) jPerson ["LNAME"];
                
                COUNTRY = country:
                CITY= ((string) jPerson ["CITY"] == string.Empty)?city:(string) jPerson ["CITY"]; //IF CITY PROPERTY EMPTY USE CITY ELSE USE JSON PROPERTY
                
             }  
               public string FNAME{ get; set; }
               public string LNAME{ get; set; }
               public string CITY{ get; set; }
               public string COUNTRY{ get; set; }         
    }

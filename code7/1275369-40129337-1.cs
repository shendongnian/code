    public class Person {
       public string FirstName {get;set}
       public string SecondName {get;set}
       public string Name => $"{FirstName} {SecondName}";
       
       public void migrate_1(JToken token, JsonSerializer s){
          var name = token["Name"];
          var names = names.Split(" ");
          token["FirstName"] = names[0];
          token["SecondName"] = names[1];
          return token;
       }
    }
    

    public class Dog{
     public string Name;
     public int Age;
     public string CreatedBy;
  
     public Dog(){
         this.CreatedBy = "parameterless constructor";
     }
     public Dog(string n, int age){
      this.Name = n;
      this.Age = age;
      this.CreatedBy = "two parameters constructor";
     }
     public Dog(string n){
      this.Name = n;
      this.CreatedBy = "one parameter constructor";
     }    
    }

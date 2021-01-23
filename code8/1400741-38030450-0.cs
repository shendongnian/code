       class Group{
         public string GroupName {
           get;set;
         }
    
         // I doubt if you want public "set" here: do you really want to assign a list?
         public List<User> Users {
           get;
           private set;
         }
    
         public Group() {
           // you have to create the list instance   
           Users = new List<User>();
         }
       }

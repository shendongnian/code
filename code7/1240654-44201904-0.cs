    using System;
    namespace Shweta.Question
    {
       public class User
       { }
       public class Permission
       { }
    
       public enum AccessType
       {
          none,
          full,
          other
       }
       public class Roles
       {
          public static void AddRole(string id, string name)
          {
          }
       }
       public class Shweta
       {
          public void AddUser(string ID, string Name, string Password)
          {
             ///some codes
             SaveSecurity();
          }
          public void DeleteUser(User ObjUser)
          {
          }
          public void AddPermission(string ID, string Name, AccessType Access)
          {
          }
          public void DeletePermission(Permission ObjPermission)
          {
          }
          public void AddRole(string ID, string Name)
          {
             Roles.AddRole(ID, Name);
          }
          public void SaveSecurity()
          {
             ///Saves the data
          }
          public TResult CallMethod<TResult>(Func<TResult> func)
          {
             try
             {
                return func();
             }
             catch (Exception e)
             {
                // Add Handle Exception
    
                // replace the next line by exception handler
                throw e;
             }
          }
          public void CallMethod(Action method)
          {
             this.CallMethod(() => { method(); return 0; });
    
             this.SaveSecurity();
          }
          public static void test()
          {
             var s = new Shweta();
             s.CallMethod(() => s.AddRole("theId", "theName"));
             s.CallMethod(() => s.DeleteUser(new User()));
             s.CallMethod(() => s.AddPermission("theId", "theName", AccessType.full));
             s.CallMethod(() => s.DeletePermission(new Permission()));
             s.CallMethod(() => s.AddRole("theId", "theName"));
          }
       }
    }

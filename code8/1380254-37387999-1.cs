      using System.Security.Permissions;
      ...
    
      [AttributeUsage(AttributeTargets.All)]
      public class MyInterceptAttribute: CodeAccessSecurityAttribute {
        public MyInterceptAttribute(SecurityAction action)
          : base(action) {
        }
    
        public override System.Security.IPermission CreatePermission() {
          //TODO: put relevant code here
          Console.Write("Before method execution!");
    
          return null;
        }
      }
    
      ...
    
      // We demand permissions which in turn leads to CreatePermission() call    
      [MyInterceptAttribute(SecurityAction.Demand)]  
      public void MyMethodUnderTest() {
        Console.Write("Method execution!");
      }

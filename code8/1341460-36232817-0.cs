using System.Reflection;
     private Action myAction = ()=>{};
     
     void Start()
     {
        System.Type ourType = this.GetType(); 
     
        MethodInfo mi= ourType.GetMethod("MyMethod", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
             
        if (mi!= null){
            myAction = (Action)Delegate.CreateDelegate(typeof(Action), this, mi);
        }
     } 

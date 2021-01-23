    public static List<T> GetSubControlsOf<T>(Control parent) where T : Control
    {
           var myCtrls = new List<T>();
    
           foreach (Control ctrl in parent.Controls)
           {
               // if ctrl is type of T
               if (ctrl.GetType() == typeof(T) || 
                   ctrl.GetType().IsInstanceOfType(typeof(T)))  
               {
                    myCtrls.Add(ctrl as T);
               }
               else if (ctrl.HasChildren)
               {
                    var childs = GetSubControlsOf<T>(ctrl);    
                    if (childs.Any()) 
                       myCtrls.AddRange(childs);
               }
           }
    
           return myCtrls;
     }

    public static List<T> GetSubControlsOf<T>(Control parent) where T : class
    {
           var myCtrls = new List<T>();
    
           foreach (Control ctrl in parent.Controls)
           {
               if (ctrl.GetType() == typeof(T) || ctrl.GetType().IsInstanceOfType(typeof(T)))  // if ctrl is type of T
               {
                    myCtrls.Add(ctrl as T);
               }
               else if (ctrl.HasChildren)
               {
                    var childs = GetSubControlsOf<T>(ctrl);
    
                    if (childs.Any()) myCtrls.AddRange(childs);
               }
           }
    
           return myCtrls;
     }

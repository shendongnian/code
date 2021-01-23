    class Class_Name
    {
        public static void StartSession(string val1, string val2)
        {
            var cn = new Class_Name();
            cn.Start(val1, val2);
            HttpContext.Current.Session["class_name"] = cn;
        }
  
        // all your classes that need access to theis session object will need 
        // to call this Instance property
        public static Class_Name Instance 
        {
           get 
           {
              return HttpContext.Current.Session["class_name"] as Class_Name;
           }
        }
        public static void EndSession()
        {
            var cn = Instance;
            if (cn != null) 
            {
                 cn.End():
            }
        }      
    }

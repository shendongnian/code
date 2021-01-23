    public class ExceptionGenerator
    {
        public static void Do()
        {
            ClassToSet clas = new ClassToSet();
            Type t = clas.GetType();
            PropertyInfo pInfo = t.GetProperty("Title");
            try
            {
                pInfo.SetValue(clas, "test", null);
            }
            catch (Exception Ex)
            {
                Debug.Print("Trapped");
            
            }
        }
    }
    class ClassToSet
    {
        public string Title {
            set {
                throw new ArgumentException();
            
            }
        
        }
    
    }

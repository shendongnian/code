     public class Wakeup : World
        {
           public void MethodA(string text)
               {
                   Log.writeline(text);
               }
        }
     public class Hello : World
        {
            public void MethodB()
                {
                    Wakeup p = new Wakeup();
                    p.MethodA("Wakeup World");
                }
        }

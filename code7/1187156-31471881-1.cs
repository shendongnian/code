    public class Program
    {
        private static int first = 0, second = 0;
        private static void Log(Exception ex, bool last = false)
        {
            var st = new StackTrace(ex, true);
            var frame = st.GetFrame(0);
            if(last)
            {
                second = frame.GetFileLineNumber();
                Console.WriteLine("Total lines: {0}", second - first);
            }
            else
            {
                first = frame.GetFileLineNumber();
            }
        }
    
        private static void Test()
        {
            try { throw new Exception("Ex1"); } catch(Exception ex) { Log(ex); }
    
            int a = 5;
            string b = "text";
            bool c = false;
    
            try { throw new Exception("Ex2"); }catch(Exception ex) { Log(ex, true); }
        }
    
        private static void Main()
        {
            Test();
            Console.ReadLine();
        }
    }

    [DllImport("kernel32.dll")]
    static extern void Sleep(uint dwMilliseconds);
    
    // code added by g. sharp @ http://www.paradisim.net
    public class MainApp
    {
        [STAThread]
        public static void Main()
        {
            Sleep(U2000);  // pause for two seconds
            System.Threading.Thread.Sleep(2000); // does the same thing
        }
    }

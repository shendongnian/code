    public class Program
        {
            public static void Main()
            {
                WpfApplication3.MainWindow win = new WpfApplication3.MainWindow();
                Status status = new Status();
                if (!File.Exists("logindata.xml"))
                {
                    status = Status.JustInstalled;
                    if (status == Status.JustInstalled)
                    {
                       win.loginlabel.Content = "Please enter your desired username and password.";
    
                    }
                    
                    Application.Run(win);
                }
            }
        }

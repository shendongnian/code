    public class MyDLLClass
    {
        public MyDLLClass()
        {
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }
        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            //Your thread handling code...
        }
    }

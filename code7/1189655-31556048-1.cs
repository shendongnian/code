    public class foo
    {
        static void Main(string[] args)
        {
            // add the exit handler
            AppDomain.CurrentDomain.ProcessExit += new EventHandler (OnProcessExit); 
            // your code
        }
    
        // will be called on exit
        static void OnProcessExit (object sender, EventArgs e)
        {
            // save your data
            myEntity.SaveChanges();
        }
    }

    [ComVisible(true)]
    public class ScriptManager
    {
        // This method can be called from JavaScript.
        public void WriteConsole(string output)
        {
            // Call a method on the form.
            Console.WriteLine(output);
        }
    }

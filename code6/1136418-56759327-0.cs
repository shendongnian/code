csharp
static class Program
{
    [STAThread]
    //add in the string[] args parameter
    static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        //pass in the args to the form constructor
        Application.Run(new Form1(args));
    }
}
**Form1.cs**
csharp
//add in the string[] args parameter to the form constructor
public Form1(string[] args)
{
    InitializeComponent();
    
    //if there was a file dropped..
    if (args.Length > 0)
    {
        var file = args[0];
        //do something with the file now...
    }
}

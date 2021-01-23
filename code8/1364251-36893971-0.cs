public class Globals
{
    public int E;
}
static void Main()
{
    var globals = new Globals { E = 1 };
    var _scriptState = CSharpScript.RunAsync("System.Console.WriteLine(E)", globals: globals).Result;
    globals.E = 2;
    var x = _scriptState.ContinueWithAsync("System.Console.WriteLine(E)").Result;
}

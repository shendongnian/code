    public interface ICommand<TArg, TResult>
    {
    	TArg Arg { get; set; }
    	TResult Run();
    }
    
    public sealed class ConvertCommand : ICommand<string, double>
    {
    	public string Arg { get; set; }
    	
    	public double Run()
    	{
    		return Convert.ToDouble(Arg);
    	}
    }
    
    public static class CommandFactory
    {
    	public static TCommand Create<TCommand, TArg, TReturnValue>(TArg arg)
    		where TCommand : ICommand<TArg, TReturnValue>, new ()
    	{
    		var cmd = new TCommand();
    		cmd.Arg = arg;
    		return cmd;
    	}
    	
        // This is like a shortcut method/helper to avoid providing 
        // generic parameters that can't be inferred...
    	public static ConvertCommand ConvertCommand(string arg)
    	{
    		return Create<ConvertCommand, string, double>(arg);
    	}
    }
    
    class Interpreter
    {
    	public TReturnValue Run<TArg, TReturnValue>(ICommand<TArg, TReturnValue> cmd)
    	{
    		return cmd.Run();
    	}
    }

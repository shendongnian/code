    // Base interface
    public interface ICommandSender
    {
        // Shared definition
        IVIClass ivi;
    }
    public class A : ICommandSender
    {
        // A code here
    }
    public class B : ICommandSender
    {
        // B code here
    }
    // Extension Methods are held in a static class (think Façade Pattern)
    public static class ExtMethods
    {
        // Accept the source and cmd 
        // The this keyword indicates the target type.
        public static void SendCommand(this ICommandSender source, string cmd)
        {
            source.ivi.Send(cmd);
        }
    }
    // Main doesn't change at all.
    class Main()
    {
        //I want my main to keep this format
        A a = new A();
        B b = new B();
    
        a.SendCommand("commands");
        b.SendCommand("commands");
    }

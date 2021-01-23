    void Main()
    {
        ControlCharacter control = new ControlCharacter();
        control.GetType()
               .GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
               .Where(method => method.GetCustomAttribute<RPC>() == null)
               .Select(method => method.Name)
               .ToList()
               .ForEach(Console.WriteLine);
    }
    
    [AttributeUsage(AttributeTargets.Method)]
    public class RPC : Attribute
    {
    }
    public class NetworkBehavior
    {
    }
    public class ControlCharacter : NetworkBehavior
    {
        [RPC] 
        public void Move() { }
        public void DrawHud() { }
    }

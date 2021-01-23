    public enum Command
    {
        None,
        LogIn,
        LogOut,
        Recovery,
        Register,
        Exit
    }
    public class CommandParameter
    {
        public dynamic Obj { get; set; }
        public Command Command { get; set; }
        public string Link_1 { get; set; }
        public string Link_2 { get; set; }
    }

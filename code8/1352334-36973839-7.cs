    public enum Command
    {
        None,
        LogOn,
        Recovery,
        Regester,
        Exit
    }
    public class CommandParameter
    {
        public object Obj { get; set; }
        public Command Command { get; set; }
        public string Link_1 { get; set; }
        public string Link_2 { get; set; }
    }

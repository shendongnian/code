    interface ICommand  
    {  
       void Execute();
       string GroupName { get; }
    } 
    class CommandImpl1 : ICommand 
    {
      void Execute() { ... }
      string GroupName { get { return "group1"; }
    }
    class CommandImpl2 : ICommand 
    {
      void Execute() { ... }
      string GroupName { get { return "group1"; }
    }

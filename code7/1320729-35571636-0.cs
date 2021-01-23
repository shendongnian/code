    public static class Shell
    {
       public static string Property {get; set;}
    }
    
    public class SomeOtherClass
    {
       public vod ShowShellPropery()
       {
          MessageBox.Show(Shell.Property);
       } 
    }

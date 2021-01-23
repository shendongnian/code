    public static class Shell
    {
       private static IPage CurrentPage { get; set; }
       public static void SetCurrentPage(IPage page)
       {
          CurrentPage = page;
       }
    }
    
    public class SomeOtherClass
    {
       public vod ShowShellPropery()
       {
          MessageBox.Show(Shell.Property);
       } 
    }

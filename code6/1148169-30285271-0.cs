    class GlobalVariables
    {
       public static GlobalVariables Instance = new GlobalVariables();
       public readonly string VAR1;
       public readonly char[] VAR2;
       public readonly int VAR3;
       private GlobalVariables()
       {
          // Set values based on the App.config options
       }
    }

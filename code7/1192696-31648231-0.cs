    var a = Type.GetType("String"); // Returns null - not enough information to find the type
    var b = Type.GetType("System.String"); // typeof(string), because mscorlib is loaded
    var c = Type.GetType("System.Windows.Forms.Form, System.Windows.Forms");
            // Works even when System.Windows.Forms isn't loaded
    var d = Type.GetType("System.Windows.Forms.Form, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
            // Also checks for proper version and signature. 
            // This is System.Windows.Forms from Microsoft.

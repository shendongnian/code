    /// <summary> Indicate a variable must be given a value 
    /// in the same line it's declared </summary>
    public class ImportantAttribute : Attribute {}
    public class Program
    {
       [Important]
       object thisShouldError;
       object thisIsFine;
    }

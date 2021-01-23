    public class YourExampleList<T>
    {
         // Example of your inner list
         private List<T> _list { get; set; }
         // Use the Count property to expose a public "Length" equivalent
         public int Length { get { return _list.Count; } }   
    }

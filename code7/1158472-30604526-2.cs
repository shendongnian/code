     public class YourObject
     {
         public ICommand ItemClick { get { return new ItemClickCommand(); } }
         public string Name { get; set; }
     }

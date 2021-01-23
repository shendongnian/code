    namespace ExtLib
    {
        public class Properties
        {
            public virtual int fieldN1 { get; set; }
            public virtual int fieldN2 { get; set; }
            public virtual int fieldN3 { get; set; }
            public virtual int fieldN4 { get; set; }
            public virtual int fieldN5 { get; set; }
        }
    }
    
    namespace MyLib
    {
        abstract class Extensions : ExtLib
        {
            public virtual int fieldM1 { get; set; }
            public virtual int fieldM2 { get; set; }
            public virtual int fieldM3 { get; set; }
            public virtual int fieldM4 { get; set; }
            public virtual int fieldM5 { get; set; }
        }
    }
    
    namespace MyProject
    {
        public class MyModel : Extensions
        {
            // contains all fields from ExtLib.Properties AND MyLib.Extensions
        }
    }

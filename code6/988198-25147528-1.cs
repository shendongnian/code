    //From File1.cs
    using System.Baz;
    namespace Example
    {
        using System.Foo;
    
        public partial class Bar
        {
            //The using statement for Foo and Baz will be in effect here.
        }
    }
    
    
    //From File2.cs
    namespace Example
    {
        partial class Bar
        {
            //The using statement for Foo and Baz will NOT be in effect here.
        }
    }

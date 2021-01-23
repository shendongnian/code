    //From File1.cs
    using System.Baz;
    namespace Example
    {
        using System.Foo;
        //The using statement for Foo and Baz will be in effect here.
        partial class Bar
        {
            //The using statement for Foo and Baz will be in effect here.
        }
    }
    namespace Example
    {
        //The using statement for Baz will be in effect here but Foo will not.
        partial class Bar
        {
            //The using statement for Baz will be in effect here but Foo will not.
        }
    }
    
<!---->
    //From File2.cs
    namespace Example
    {
        //The using statement for Foo and Baz will NOT be in effect here.
        partial class Bar
        {
            //The using statement for Foo and Baz will NOT be in effect here.
        }
    }

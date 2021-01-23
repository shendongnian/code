    using System.Data.Linq.Mapping;
    namespace SameNamespaceAsDataContext
    {
        partial class SameClassnameAsDataContext
        {
            [Function(Name = "ISNUMERIC", IsComposable = true)]
            public int IsNumeric(string input)
            {
                throw new NotImplementedException(); // this won't get called
            }
        }
    }

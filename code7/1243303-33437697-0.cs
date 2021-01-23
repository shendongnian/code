    namespace ODataClient.ServiceReference1  // Match the namespace of the Reference.cs partial class
    {
        public partial class Books  // Your entity
        {
            public bool HasChanges { get; set; } = false;  // Your new property!
            partial void OnIdChanging(int value)  // Boilerplate
            {
                if (Id.Equals(value)) return;
                HasChanges = true;
            }
            partial void OnBookNameChanging(string value)  // Boilerplate
            {
                if (BookName == null || BookName.Equals(value)) return;
                HasChanges = true;
            }
            // etc, ad nauseam
        }
        // etc, ad nauseam
    }

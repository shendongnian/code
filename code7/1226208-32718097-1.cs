    namespace WebApplication1.Code
    {
        public class MyModel
        {
            public string Name { get; set; }
    
            public static IEnumerable GetSearchResults(int myCount)
            {
                for (int i = 0; i < myCount; i++)
                {
                    yield return new MyModel { Name = "item " + i };
                }
            }
        }
    }

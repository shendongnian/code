    namespace GenericMethod
    {
        public class GenericMethodClass
        {
            public T[] SortArrayOfObjects<T>(object[] dataSource, string propertyName, string sortDirection)
            {
                string sortExpression = string.Format("{0} {1}", propertyName, sortDirection);
                // sortExpression will be something like "FirstName DESC".
                // OrderBy method takes expression as string like "FirstName DESC".
                // OrderBy method exists in "System.Linq.Dynamic" dll.
                // Download it from www.nuget.org/packages/System.Linq.Dynamic/
                T[] arrSortedObjects = dataSource.Cast<T>().OrderBy(sortExpression).ToArray();
                return arrSortedObjects;
            }
        }
    }

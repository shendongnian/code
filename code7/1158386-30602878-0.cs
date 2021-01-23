    using System.Linq;
    using FastMember;
    
    namespace Utilities
    {
        public static class TrimStringProperties
        {
            /// <summary>
            /// An extension method that can be called on class instances.  It will trim
            /// all public string properties in the class instance.
            /// </summary>
            /// <remarks>
            /// Utilizies FastMember, which relies internally on IL and Caching to 
            /// maintain better performance than Reflection.
            /// </remarks>
            public static void TrimAllStringProperties<T>(this T model) where T : class
            {
                var accessor = TypeAccessor.Create(model.GetType());
                TrimAllStringProperties(model, accessor);
            }
    
            /// <summary>
            /// An extension method that can be called on collections.  It will trim
            /// all public string properties in each class instance in the collection.
            /// </summary>
            /// <remarks>
            /// Utilizies FastMember, which relies internally on IL and Caching to 
            /// maintain better performance than Reflection.
            /// </remarks>
            public static void TrimAllStringPropertiesInCollection<T>(this IEnumerable<T> collection)
                where T : class
            {
                var mappedCollection = collection.ToList();
                if (!mappedCollection.Any()) return;
    
                TrimEachInstanceInCollection(mappedCollection);
            }
    
            private static void TrimEachInstanceInCollection<T>(List<T> collection)
            {
                var accessor = TypeAccessor.Create(collection.First().GetType());
                foreach (var item in collection)
                {
                    TrimAllStringProperties(item, accessor);
                }
            }
    
            private static void TrimAllStringProperties<T>(T model, TypeAccessor accessor)
            {
                GetStringProperties(accessor).ForEach(x => SetValue(model, accessor, x));
            }
    
            private static List<Member> GetStringProperties(TypeAccessor accessor)
            {
                return accessor.GetMembers().Where(x => x.Type == typeof(string)).ToList();
            }
    
            private static void SetValue<T>(T model, TypeAccessor accessor, Member member)
            {
                var value = accessor[model, member.Name];
    
                if (value != null)
                    accessor[model, member.Name] = value.ToString().Trim();
            }
        }
    }

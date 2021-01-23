        private static dynamic ConvertList<T>(IEnumerable<T> inputList, Type type)
        {
            var innerType = type.GenericTypeArguments.First(); //innerType is like: MyInterface
            Wrapper result1 = new Wrapper();
            result1.Property = inputList.Select(item => Convert.ChangeType(item, innerType));
            dynamic result2 = Convert.ChangeType(result1, type);
            return result2;
        }
    
        public class Wrapper : IConvertible
        {
            public System.Collections.Generic.IEnumerable<object> Property { get; set; }
            //implement here all the methods required by Iconvertable
        }

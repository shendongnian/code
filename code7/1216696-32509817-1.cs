    public class TestClass
    {
        public static void Test()
        {
            A refObject = A.Empty; // Add reference with static object(Empty)
            Test(refObject, true);
            A dummy = new A(); // No global singleton for this one.
            Test(dummy, false);
        }
        private static void Test(A refObject, bool shouldBeEqual)
        {
            Console.WriteLine(string.Format("refObject and A.Empty are {0}.", object.ReferenceEquals(refObject, A.Empty) ? "identical" : "different"));
            var binary = BinaryFormatterHelper.ToBase64String(refObject);
            var DeserializedObject = BinaryFormatterHelper.FromBase64String<A>(binary);
            Console.WriteLine(string.Format("DeserializedObject and A.Empty are {0}.", object.ReferenceEquals(refObject, A.Empty) ? "identical" : "different"));
            Debug.Assert(object.ReferenceEquals(refObject, A.Empty) == object.ReferenceEquals(DeserializedObject, A.Empty)); // No assert
            Debug.Assert(shouldBeEqual == object.ReferenceEquals(refObject, DeserializedObject)); // No assert
        }
    }
    public static class BinaryFormatterHelper
    {
        public static string ToBase64String<T>(T obj)
        {
            using (var stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, obj);
                return Convert.ToBase64String(stream.GetBuffer(), 0, checked((int)stream.Length)); // Throw an exception on overflow.
            }
        }
        public static T FromBase64String<T>(string data)
        {
            return FromBase64String<T>(data, null);
        }
        public static T FromBase64String<T>(string data, BinaryFormatter formatter)
        {
            using (var stream = new MemoryStream(Convert.FromBase64String(data)))
            {
                formatter = (formatter ?? new BinaryFormatter());
                var obj = formatter.Deserialize(stream);
                if (obj is T)
                    return (T)obj;
                return default(T);
            }
        }
    }

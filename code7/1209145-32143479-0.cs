    class Program
    {
        static void Main()
        {
            Console.WriteLine(SerializeToString(new Person { Name = "Alex", Age = 42, NullableId = null }));
        }
        public static string SerializeToString<T>(T instance)
        {
            using (var ms = new MemoryStream())
            {
                var serializer = new DataContractSerializer(typeof(T));
                serializer.WriteObject(ms, instance);
                ms.Seek(0, SeekOrigin.Begin);
                using (var sr = new StreamReader(ms))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int? NullableId { get; set; }
    }

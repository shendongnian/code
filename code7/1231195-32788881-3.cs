    public class Scene
    {
        public string Name { get; set; } // Or whatever
    }
    [DataContract]
    public class Primitive
    {
        [DataMember]
        public string type;
        [DataMember]
        public float[] vertices;
        [DataMember]
        public int[] indices;
        [DataMember]
        public int[] edgeIndices;
        [IgnoreDataMember]
        public Scene scene;
    }
    public class TestClass
    {
        public static void Test()
        {
            var primitive = new Primitive
            {
                type = "some type",
                vertices = new[] { 1.0f, 2.0f },
                indices = new[] { 1, 2 },
                edgeIndices = new[] { 0, 1 },
                scene = new Scene { Name = "Should Not Be Serialized" }
            };
            var writer = new JsonWriter(new DataWriterSettings(new DataContractResolverStrategy()));
            var json = writer.Write(primitive);
            Debug.WriteLine(json);
            Debug.Assert(!json.Contains("Should Not Be Serialized")); // No assert
        }
    }

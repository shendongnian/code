    public class Scene
    {
        public string Name { get; set; } // Or whatever
    }
    public class Primitive
    {
        public string type;
        public float[] vertices;
        public int[] indices;
        public int[] edgeIndices;
        [JsonFx.Json.JsonIgnore]
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
            var writer = new JsonWriter(new DataWriterSettings(new JsonResolverStrategy()));
            var json = writer.Write(primitive);
            Debug.WriteLine(json);  // Prints {"type":"some type","vertices":[1,2],"indices":[1,2],"edgeIndices":[0,1]}
            Debug.Assert(!json.Contains("Should Not Be Serialized")); // No assert
        }
    }

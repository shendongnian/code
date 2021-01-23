    public static class JsonSerializerTest
    {
        static JsonSerializerTest()
        {
            // This needs to be done only once, so put it in an appropriate static initializer.
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new XYZConverter() }
            };
        }
        public static void Test()
        {
            Points points = new Points();
            points.bboxmin = new XYZ(-100, -100, -1000);
            points.bboxmax = new XYZ( 100,  100,  1000);
            points.sboxmin = new XYZ(-10, -10, -100);
            points.sboxmax = new XYZ( 10, 10, 100);
            try
            {
                string json;
                using (var writer = new StringWriter())
                {
                    JsonSerializer serializer = JsonSerializer.CreateDefault();
                    serializer.Serialize(writer, points);
                    json = writer.ToString();
                }
                Points newPoints = null;
                using (var reader = new StringReader(json))
                {
                    JsonSerializer serializer = JsonSerializer.CreateDefault();
                    newPoints = (Points)serializer.Deserialize(reader, typeof(Points));
                }
                Debug.Assert(points.bboxmin.IsAlmostEqualTo(newPoints.bboxmin));
                Debug.Assert(points.bboxmax.IsAlmostEqualTo(newPoints.bboxmax));
                Debug.Assert(points.sboxmin.IsAlmostEqualTo(newPoints.sboxmin));
                Debug.Assert(points.sboxmax.IsAlmostEqualTo(newPoints.sboxmax));
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.ToString());
            }
        }
    }

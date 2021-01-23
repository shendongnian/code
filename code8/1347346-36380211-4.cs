    public class FaceRectangle
    {
        public int left { get; set; }
        public int top { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
    public class Emotion
    {
        public FaceRectangle faceRectangle { get; set; }
        public IDictionary<string, double> scores { get; set; }
    }

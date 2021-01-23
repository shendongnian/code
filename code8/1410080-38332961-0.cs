    public class DrawingResult {
        public Image<Bgr, Byte> Images { get; private set; }
        public int Count {get; private set; }
        public DrawingResult(Image<Bgr, Byte> images, int count) {
           Images = images;
           Count = count;
        }
    }

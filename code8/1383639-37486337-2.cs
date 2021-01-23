As asked in comment, for perserving position using decimal numbers (float), you could store 3 variables (position, width and height) in float and create a function, or a variable that will represent those variables in Rectangle. Doing this will perserve more information (because everything is stored in decimal numbers) and give you functionality that Rectangle class provides. That would look something like this (not tested):
    public class BoundingBox: Rectangle
    {
        // PUBLIC
        public Vector2 Position;
        public float Width, Height,
        public Rectangle Box
        { get { return new Rectangle((int)Position.X, (int)Position.Y, (int)Width, (int)Height); } }
        // or, if you don't understand get/set, create function
        public Rectange Box()
        { return new Rectangle((int)Position.X, (int)Position.Y, (int)Width, (int)Height); } 
    }

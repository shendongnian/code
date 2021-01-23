    abstract class Scene
    {
        public string text;
    
        public abstract void preDraw();
        public abstract void postDraw();
    
        Button[] buttons;
    
        public Scene(string text)
        {
    
        }
    }

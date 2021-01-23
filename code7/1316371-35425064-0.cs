    public class SceneBase
    {
        public string text;
    
        public virtual void preDraw() { }
        public virtual void postDraw() { }
    
        protected Button[] buttons;
    
        public Scene(string text)
        {
         
        }
    }

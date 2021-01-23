    public class SceneBase
    {
        public string text;
    
        public virtual void preDraw() { }
        public virtual postDraw() { }
    
        Button[] buttons;
    
        public Scene(string text)
        {
         
        }
    }

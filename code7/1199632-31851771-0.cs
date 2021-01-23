    public abstract class App
    {
        protected void MouseMove()
        {
            // Engine code here
        }
    
        protected abstract void OnMouseMove(object etc);
    }
    
    public class ProjectName : App
    {
        protected override void OnMouseMove(object etc)
        {
            // User code here
        }
    }

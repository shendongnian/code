    class GameEngine
    {
        public void update(ref Form1 caller)
        {
            caller.Refresh() //msdn says "Forces the control to invalidate its client area and immediately redraw itself and any child controls."
        }
    }
    public partial class Form1 : Form
    {
        [...]
        engine = new GameEngine()
        engine.update(ref This)
    }

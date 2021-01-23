    public partial class Form1 : Form
    {
        GameEngine engine;
        public Form1()
        {
            engine = new GameEngine();
            engine.update(this);
        }
    
        public void repaint()
        {
    
        }
    }
    
    class GameEngine
    {
        public void update(Form1 form)
        {
            form.repaint();
        }
    }

    public partial class Form1 : Form
    {
        GameEngine engine;
        public Form1()
        {
            engine = new GameEngine();
            // I put the call here for demo purpose,
            // of course you call the engine.update 
            // method when you need and where you want 
            engine.update(repaint)
        }
    
        public void repaint()
        {
            Console.WriteLine("repaint called in the Form1 instance");
        }
    }
    
    class GameEngine
    {
        public void update(Action clientUpdate)
        {
           if(clientUpdate != null)
              clientUpdate.Invoke();
        }
    }

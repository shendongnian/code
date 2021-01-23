    class Scene
    {
        public string text;
    
        public Action PreDraw {get; set;}
        public Action PostDraw {get; set;}
    
    
        public Scene(string text, Action preDraw)
        {
            text = text;
            PreDraw = preDraw;
        }
    }
    
    
    static class Scenes
    {
        public static Scene name = new Scene("What is your name?", () => Console.WriteLine("PreDraw the name."));
        public static Scene age = new Scene("How old are you?", () => Console.WriteLine("PreDraw the age."));
    }

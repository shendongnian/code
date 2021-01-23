    class Scene
    {
        public string text;
    
        public Action preDraw{get;set; }
        public Action postDraw{get;set; }
    
        Button[] buttons;
    
        public Scene(string text)
        {
    
        }
    }
    static class Scenes
    {
        public static Scene name = new Scene("What is your name?");
        name.preDraw=new Action(()=>{Console.WriteLine("preDraw by name");});
        name.postDraw=new Action(()=>{Console.WriteLine("postDrawby name");});
        public static Scene age = new Scene("How old are you?");
        age.preDraw=new Action(()=>{Console.WriteLine("preDraw by age");});
        age.postDraw=new Action(()=>{Console.WriteLine("postDrawby age");});
    }

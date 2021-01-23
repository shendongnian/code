        public class SceneManager
        {
             // private constructor means other classes cannot instantiate this
             private SceneManager() { }
             private static readonly SceneManager _instance = new SceneManager();
             public static SceneManager Instance
             { 
                 get { return _instance; }
             }
        }
    If you now try to pull this off in your `Game` class:
        var sceneManager = new SceneManager();
    your compiler will tell you it's not going to work that way.

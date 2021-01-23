    This is **wrong**:
        public void Initialize()
        {
             var mainScene = = new MainMenuScene();
             instance.sceneDirectory["MainMenuScene"] = mainScene;
             instance.currentScene = mainScene;
        }
    But this is fine (and the `this` keyword is redundant, of course):
        public void Initialize()
        {
             var mainScene = = new MainMenuScene();
             this.sceneDirectory["MainMenuScene"] = mainScene;
             this.currentScene = mainScene;
        }
    Because you're going to use it like this anyway:
        // you're basically doing the same thing, but
        // it's immediately clear what's going on, and there
        // is no room for errors:
        var manager = SceneManager.Instance;
        manager.Initialize();
    The simplest way to ensure you're doing it right it to remove all references to `instance` inside the `SceneManager` class.

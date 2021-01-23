    static void Main()
            {
                var Red = new GameObject();
                var Yellow = new GameObject();
    
                List<GameObject> gameObjects = new List<GameObject>() { Red, Yellow };
                var randomGameObject = gameObjects[(new Random()).Next(gameObjects.Count)];
    
                // color = Instantiate(randomGameObject)
    
                //Console.WriteLine(randomGameObject);
                Console.ReadLine();
            }

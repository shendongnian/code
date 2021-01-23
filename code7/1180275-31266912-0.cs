    public List<Character> characters = new List<Character>();   ///Thanks to public 
                                                  //you can see list in Unity Editor
    private List<GameObject> characterGameObjects = new List<GameObject> ();
    
    public void loadSceneCharacters(){
    
        if (characters != null) {
            for(int i = 0; i < characters.Count; i++){
                characterGameObjects.Add(characters[i]));  //get and add gameobject
                characterGameObjects[i].SetActive(true);
            }
        }
    }

     public List<GameObject>  myListofGameObject = new List<GameObject>();
     Start(){
        myListofGameObject.Add(GameObject.FindGameObjectsWithTag("TagName"));
        myListofGameObject.Add(GameObject.FindGameObjectsWithTag("TagName2"));
        myListofGameObject.Add(GameObject.FindGameObjectsWithTag("TagName3"));
        foreach(GameObject gc in myListofGameObject){
            
               Debug.Log(gc.name);
        }
     }

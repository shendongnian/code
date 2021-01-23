     public List<GameObject>  myListofGameObject = new List<GameObject>();
     Start(){
        myListofGameObject.AddRange(GameObject.FindGameObjectsWithTag("TagName"));
        myListofGameObject.AddRange(GameObject.FindGameObjectsWithTag("TagName2"));
        myListofGameObject.AddRange(GameObject.FindGameObjectsWithTag("TagName3"));
        foreach(GameObject gc in myListofGameObject){
            
               Debug.Log(gc.name);
        }
     }

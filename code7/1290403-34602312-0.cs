    GameObject playerReference = GameObject.Find("Player");
    
    void Update(){
        if (GameObject.Find("pushBlockCollider").GetComponent<pushBlockCollider>().inPushBlock){
    
            Debug.Log ("got to pushblockCollider True");
  
    }

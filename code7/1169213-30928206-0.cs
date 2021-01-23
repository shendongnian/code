    void Start () {
         guiTexture.pixelInset = new Rect (0, 0, Screen.width, Screen.height);
         StartCoroutine (LoadNextScene ());
     }
     IEnumerator LoadNextScene(){
         Debug.Log ("before wait. Pausing for seconds: " + DelayTime);
         yield return new WaitForSeconds (DelayTime);
         Debug.Log ("after wait");
         if (NextLevel != "") {
             Application .LoadLevel (NextLevel );    
         }
     }
    
    void OnDestroy() {
            Debug.Log("Destroyed");
    }

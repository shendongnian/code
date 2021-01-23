    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
    void Start(){
        if (Application.loadedLevel == 1){
            GameObject.Find("object1").GetComponent<MeshRenderer>().enabled = false;
        }
        else{
            //Other actions...
        }
    }

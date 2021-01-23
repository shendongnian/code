    void Start () 
    {
        //activate camera because I am lazy
        var cam = GameObject.Find ("camera");
        var ball = GameObject.Find ("ball");
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        cam.SetActive (true);
        Debug.Log("Start Called!");
    }
    void Update () 
    {
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision detected: "+col.gameObject.name);
        if (col.gameObject.tag  ==  "Bricks") {
           #if UNITY_EDITOR
           UnityEditor.EditorApplication.isPlaying = false;
           #else
           Application.Quit();
           #endif
         }
    }

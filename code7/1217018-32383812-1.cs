    bool showGui = false;
    
    public void Update(){
        if (Input.GetKey(KeyCode.Tab)) 
        {
            showGui = true;
        }
    }
    
    public void OnGUI()
    {
        if (showGui) 
        {
            GUI.contentColor = Color.white;
            GUI.Box(new Rect(1000, 5, 400, 400), "What You Should Know");
            GUI.Label(new Rect(1135, 5, 400, 400), "___________________");
            GUI.Label(new Rect(1145, 23, 400, 400), "<color=cyan><size=20>The </size></color>" + "<color=cyan><size=20>" + this.cdrw + "</size></color>");
        }
    }

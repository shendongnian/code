    public Sprite sp1;
    public Button level2;
    void Start(){
         level2 = GameObject.Find ("level2").GetComponent<Button> ();
         level2.image.sprite = sp1;
    }

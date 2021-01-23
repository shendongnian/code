    public Vector2 gridPos = Vector2.zero;
    Renderer r;
    public Color colorStart = Color.red;
    public Color colorEnd = Color.green;
    public float duration = 1.0F;
    private float lerp;
    // Use this for initialization
    void Start () {
        r = GetComponent<Renderer>();
        lerp = Mathf.PingPong(Time.time, duration) / duration;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseEnter()
    {
        
        r.material.color = Color.Lerp(colorStart, colorEnd, lerp);
        //r.material.color = Color.black;
        Debug.Log("X pos = "+ gridPos.x + "Y pos = "+ gridPos.y);
    }
    void OnMouseExit()
    {
        r.material.color = Color.Lerp(Color.white, Color.white,lerp);
    }
}

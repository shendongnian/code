    public Slider healthSlider;
    public GameObject healthRect;
    private float sliderSize = 100;
    private RectTransform healthRectTransform;
    void Start()
    {
        healthRectTransform = healthRect.GetComponent<RectTransform>();
    }
        
    void Update ()
    {
        healthRectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, sliderSize);
        sliderSize += Time.deltaTime;
    }

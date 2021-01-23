    public Slider healthSlider;
    public GameObject healthRect;
    private float sliderSize = 100;
    
    void Update ()
    {
        healthRect.GetComponent<RectTransform> ().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, sliderSize);
        sliderSize += Time.deltaTime;
    }

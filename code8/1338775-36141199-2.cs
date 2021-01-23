    public Texture[] frames;                // array of textures
    public float framesPerSecond = 2.0f;    // delay between frames
    RawImage image = null; 
    
    void Start()
    {
     image = gameObject.GetComponent<Image>();
    }
    void Update()
    {
      image = gameObject.GetComponent<Image>();
      int index = (int)(Time.time * framesPerSecond) % frames.Length;
      image.texture = frames[index]; //Change The Image
    }

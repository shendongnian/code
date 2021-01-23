    public Texture[] frames;                // array of textures
    public float framesPerSecond = 2.0f;    // delay between frames
    Image image = null;
    
    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }
    void Update()
    {
            int index = (int)(Time.time * framesPerSecond) % frames.Length;
    
            //Convert Texture to Sprite
            Sprite s = Sprite.Create((Texture2D)frames[index], new Rect(0, 0, frames[index].width, frames[index].height),
                                    Vector2.zero, 0);
            image.sprite = s; //Change The Image
    }

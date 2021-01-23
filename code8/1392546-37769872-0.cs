    //Assign Sprite from Editor. (Where to display the loaded image sprite)
    public Image displaySprite;
    
    void loadImage()
    {
        //Load Image
        Texture2D tex = Resources.Load("pig", typeof(Texture2D)) as Texture2D;
        if (tex != null)
        {
            //Create new Sprite from the Loaded Sprite
            Sprite sp = new Sprite();
            sp = Sprite.Create(tex, new Rect(0, 0, 100, 100), new Vector2(0.5f, 0.5f), 40);
            Debug.Log("Not Null");
    
            //Show Image to screen
            displaySprite.sprite = sp;
        }
        else
        {
            Debug.Log("Null");
        }
    
    }

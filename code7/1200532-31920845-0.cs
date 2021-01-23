    public void ExecuteOnTurrent()
    {
        // do stuff in turret
    }
    public void LoadSprite()
    {    
        Sprite myMenuButton = Resources.Load <Sprite> ("sprite_menu_to_load");
        myMenuButton.OnClick= ExecuteOnTurrent;
    }

    public float step = 0;
    
    void Update ()
    {
        RenderSettings.skybox.SetColor("_Tint", Color.Lerp(colorStart, colorEnd, step));
        step += Time.deltaTime / duration;
    }

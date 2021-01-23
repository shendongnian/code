    public float step = 0;
    
    private void Update ()
    {
        RenderSettings.skybox.SetColor("_Tint", Color.Lerp(colorStart, colorEnd, step));
        step += Time.deltaTime / duration;
    }

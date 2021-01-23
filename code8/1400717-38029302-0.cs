    public class DrawPixelTexture
    {
        private Texture2D t1 = new Texture2D(1, 1, TextureFormat.RGBA32, true);
    
        public DrawPixelTexture()
        {
            t1.hideFlags = HideFlags.HideAndDontSave;
        }
    
        public void txture(Rect rect, Color colour, float opacity = 1)
        {
            colour.a = opacity;
    
            // ensure that we only  call Apply() once by reading the colour of the pixel at 0,0 and seeing id it is the same as 'colour'
            if (t1.GetPixel(0, 0) != colour)
            {
                Debug.Log("still being overriden");
                t1.SetPixel(0, 0, colour);
                t1.Apply();
            }
            Graphics.DrawTexture(rect, t1);
        }
    }

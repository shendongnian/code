    public class DrawPixelTexture
    {
        private static readonly Dictionary<Color, Texture2D> texturesCache = new Dictionary<Color, Texture2D>();
        public static void ClearCache()
        {
            texturesCache.Clear();
        }
        public static void Texture(Rect rect, Color colour, float opacity = 1)
        {
            colour.a = opacity;
            Texture2D texture;
            if (!texturesCache.TryGetValue(colour, out texture))
            {
                Debug.Log("still being created");
                texture = new Texture2D(1, 1, TextureFormat.RGBA32, true);
                texture.hideFlags = HideFlags.HideAndDontSave;
                texture.SetPixel(0, 0, colour);
                texture.Apply();
                texturesCache.Add(colour, texture);
            }
            Graphics.DrawTexture(rect, texture);
        }
    }

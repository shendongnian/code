    class FrameDispatcher
    {
        private static FrameDispatcher StaticInstance;
        private Dictionary<String, FrameRenderer> Renderers = new Dictionary<string, FrameRenderer>();
        public static FrameDispatcher Instance {
            get {
                if (StaticInstance == null)
                {
                    StaticInstance = new FrameDispatcher();
                }
                return StaticInstance;
            }
        }
        public void DispatchFrame(String id, IntPtr bitmapBuffer, int bitmapBufferLength)
        {
            if (Renderers.ContainsKey(id))
            {
                BitmapSource bitmap = BitmapSource.Create(640, 480, 96, 96, PixelFormats.Pbgra32, null, bitmapBuffer, bitmapBufferLength, 640 * 8);                
                Renderers[id].SetBitmap(bitmap);                
            }
        }
        public void RegisterFrameRenderer(FrameRenderer renderer, String id)
        {
            Renderers.Add(id, renderer);
        }
        public void UnregisterFrameRenderer(String id)
        {
            Renderers.Remove(id);
        }
    }

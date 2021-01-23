    class Game : GameWindow
        {
            public int i;
        public Game()  : base(320, 240, OpenTK.Graphics.GraphicsMode.Default, "OpenTK Quick Start Sample")
        {
            VSync = VSyncMode.On;
        }    
        protected override void OnLoad(EventArgs e)
        {  
            base.OnLoad(e); 
            GL.ClearColor(0.1f, 0.2f, 0.5f, 0.0f);
            GL.Enable(EnableCap.DepthTest);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        { 
            i =1;
            //does stuff 
        }
    }

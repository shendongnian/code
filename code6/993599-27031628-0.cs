    public partial class SharpGLForm : Form
    {
        private bool TexturesInitialised = false;
        private float rotation = 0.0f;
        private float Scale = 1;
        private Bitmap gImage1;
        private System.Drawing.Imaging.BitmapData gbitmapdata;
        private uint[] gtexture = new uint[1];
        /// <summary>
        /// Initializes a new instance of the <see cref="SharpGLForm"/> class.
        /// </summary>
        public SharpGLForm()
        {
            InitializeComponent();
        }
        private void InitialiseTexture(ref OpenGL gl)
        {
            gImage1 = new Bitmap(@"C:\Jess1.bmp");// Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            Rectangle rect = new Rectangle(0, 0, gImage1.Width, gImage1.Height);
            gbitmapdata = gImage1.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            gImage1.UnlockBits(gbitmapdata);
            gl.GenTextures(1, gtexture);
            gl.BindTexture(OpenGL.GL_TEXTURE_2D, gtexture[0]);
            gl.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, (int)OpenGL.GL_RGB8, gImage1.Width, gImage1.Height, 0, OpenGL.GL_BGR_EXT, OpenGL.GL_UNSIGNED_BYTE, gbitmapdata.Scan0);
            uint[] array = new uint[] { OpenGL.GL_NEAREST };
            gl.TexParameterI(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, array);
            gl.TexParameterI(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, array);
            TexturesInitialised = true;
        }
        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            //  Load the identity matrix.
            gl.LoadIdentity();
            if (!TexturesInitialised)
            {
                InitialiseTexture(ref gl);     
            }
  
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            gl.BindTexture(OpenGL.GL_TEXTURE_2D, gtexture[0]);
            gl.Color(1.0f, 1.0f, 1.0f, 0.1f); //Must have, weirdness!
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(1.0f, 1.0f);			
            gl.Vertex(gImage1.Width, gImage1.Height, 1.0f);		
            gl.TexCoord(0.0f, 1.0f);			
            gl.Vertex(0.0f, gImage1.Height, 1.0f);		
            gl.TexCoord(0.0f, 0.0f);		
            gl.Vertex(0.0f, 0.0f, 1.0f);
            gl.TexCoord(1.0f, 0.0f);		
            gl.Vertex(gImage1.Width, 0.0f, 1.0f);		
            gl.End();
            gl.Disable(OpenGL.GL_TEXTURE_2D);
        }
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.ClearColor(0, 0, 0, 0);
        }
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 10000.0);
            gl.LookAt(0, 0, -500, 0, 0, 0, 0, 1, 0);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }
       
    }

    public class TransparentImage : DrawingArea
    {
        private bool draw = false;
        private Image Imagem;
        public Image imagem
        {
            get { return Imagem; }
            set
            {
                Imagem = value;
                draw = true;
                this.Size = Imagem.Size;
            }
        }
        protected override void InitLayout()
        {
            this.BringToFront();
        }
        public TransparentImage()
        {
        }
        protected override void OnDraw()
        {
            if (draw)
            {
                Rectangle location = new Rectangle(0, 0, Imagem.Width, Imagem.Height);
                this.graphics.DrawImage(Imagem, location);
            }
        }
    }

    public class PictureButton : Control
    {
        Image staticImage, hoverImage;
        bool pressed = false;
        
        // staticImage is the primary default button image 
        public Image staticImage
        {
            get {
                return this.staticImage;
            }
            set {
                this.staticImage = value;
            }
        }
        
        // hoverImage is what appears when the mouse enters
        public Image hoverImage
        {
            get {
                return this.hoverImage;
            }
            set {
                this.hoverImage = value;
            }
        }
        
        protected override void OnEnter(EventArgs e)
        {
            this.pressed = true;
            this.Invalidate();
            base.OnEnter(e);
        }
        
        protected override void OnLeave(EventArgs e)
        {
            this.pressed = false;
            this.Invalidate();
            base.OnLeave(e);
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.pressed && this.hoverImage != null)
                e.Graphics.DrawImage(this.hoverImage, 0, 0);
            else
                e.Graphics.DrawImage(this.staticImage, 0, 0);
            
            base.OnPaint(e);
        }
    }

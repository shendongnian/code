    public class MyBytton : Button
    {
        public Image MainImage { get; set; }
        public Image HoverImage { get; set; }
        protected override void OnMouseHover(EventArgs e)
        {
            if (HoverImage != null)
            {
                this.BackgroundImage = HoverImage;
            }
            base.OnMouseHover(e);
        }
        protected override void  OnMouseLeave(EventArgs e)
        {
            if (MainImage != null)
            {
                this.BackgroundImage = MainImage;
            }
            base.OnMouseLeave(e);
        }
    }

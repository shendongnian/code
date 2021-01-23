    public class MyBytton : Button
    {
        public Image MainImage { get; set; }
        public Image HoverImage { get; set; }
        protected override void OnMouseEnter(EventArgs e)
        {
            if (MainImage != null)
            {
                this.BackgroundImage = MainImage;
            }
            base.OnMouseEnter(e);
        }
        protected override void OnMouseHover(EventArgs e)
        {
            if (HoverImage != null)
            {
                this.BackgroundImage = HoverImage;
            }
            base.OnMouseHover(e);
        }
    }

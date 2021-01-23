    public class MyBytton : Button
    {
        public Image MainImage { get; set; }
        public Image HoverImage { get; set; }
        protected override void OnMouseEnter (EventArgs e)
        {
            if (HoverImage != null)
            {
                this.BackgroundImage = HoverImage;
            }
            base.OnMouseEnter(e);
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

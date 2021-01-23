    public class LittlePanel : Panel
    {
        public class HoverEventArgs
        {
            public bool Active { get; set; }
            public HoverEventArgs(bool active)
            {
                Active = active;
            }
        }
        public event EventHandler<HoverEventArgs> Hover;
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            OnHover(true);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            OnHover(false);
        }
        protected void OnHover(bool active)
        {
            EventHandler<HoverEventArgs> hover = Hover;
            if (hover != null) hover(this, new HoverEventArgs(active));
        }
    }

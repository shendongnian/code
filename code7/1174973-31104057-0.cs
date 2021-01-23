    class HardwareComponent : UserControl
    {
        public ComponentPanel panel = null;
        public HardwareComponent()
        {
            
        }
        protected override void OnParentChanged(EventArgs e)
        {
            if (this.panel == null && this.Parent != null)
            {
                this.panel = new ComponentPanel();
                this.panel.Location = new Point(this.Right + 5, this.Top);
                this.panel.Name = Guid.NewGuid().ToString();
                this.Parent.Controls.Add(panel);
            }
            base.OnParentChanged(e);
        }
    }

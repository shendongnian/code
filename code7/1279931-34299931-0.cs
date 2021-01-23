    public partial class MyControl : Label
    {
        #region fields
        private IComponentChangeService _changeService;
        private bool canResetText = false;
        #endregion
        #region properties
        protected override Size DefaultSize
        {
            get { return new Size(200, 132); }
        }
        [Browsable(false)]
        public override bool AutoSize
        {
            get { return false; }
            set { base.AutoSize = false; }
        }
        public override ISite Site
        {
            get { return base.Site; }
            set
            {
                base.Site = value;
                if (!base.DesignMode)
                    return;
                this._changeService = (IComponentChangeService)base.GetService(typeof(IComponentChangeService));
                if (this._changeService != null)
                    this._changeService.ComponentChanged += new ComponentChangedEventHandler(this.OnComponentChanged);
            }
        }
        #endregion
        #region constructors
        public MyControl()
        {
            base.BackColor = Color.LightCoral;
            base.BorderStyle = BorderStyle.FixedSingle;
        }
        #endregion
        #region methods
        protected override void InitLayout()
        {
            base.InitLayout();
            this.canResetText = true;
        }
        private void OnComponentChanged(object sender, ComponentChangedEventArgs ce)
        {
            if (ce.Component != null &&
                ce.Component == this &&
                ce.Member.Name == "Text" &&
                base.DesignMode &&
                this.canResetText)
            {
                ((MyControl)ce.Component).Text = string.Empty;
                this.canResetText = false;
                if (this._changeService != null)
                    this._changeService.ComponentChanged -= new ComponentChangedEventHandler(this.OnComponentChanged);
            }
        }
        #endregion
    }

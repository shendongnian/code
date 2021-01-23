    public class FixedBackgroundForm : Form
    {
        protected new static readonly Color DefaultBackColor = Color.Black;
        [Browsable(false),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }
        public FixedBackgroundForm()
        {
            this.BackColor = DefaultBackColor
        }
    }

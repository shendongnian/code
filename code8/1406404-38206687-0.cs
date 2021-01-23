    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    [Designer(typeof(MyLabelDesigner))]
    public partial class MyLabel : Control
    {
        public MyLabel() { InitializeComponent(); }
        private System.Windows.Forms.Label textLabel;
        private void InitializeComponent()
        {
            this.textLabel = new System.Windows.Forms.Label();
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(0, 0);
            this.textLabel.Name = "label1";
            textLabel.SizeChanged += new EventHandler(textLabel_SizeChanged);
            this.AutoSize = true;
            this.Controls.Add(this.textLabel);
        }
        void textLabel_SizeChanged(object sender, EventArgs e)
        {
            this.Height = this.textLabel.Bottom + 0;
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.textLabel.MaximumSize = new Size(this.Width, 0);
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return this.textLabel.Text; }
            set { this.textLabel.Text = value; }
        }
    }

    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            this.ForeColor = Color.Red;
            this.Font = new Font("Tahoma", 9, FontStyle.Italic);
            this.Width = 200;
        }
        [DefaultValue(typeof(Color), "Red")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = value; }
        }
    }

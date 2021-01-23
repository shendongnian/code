    using System.Drawing;
    using System.Windows.Forms;
    public class MyDataGridView : DataGridView
    {
        public override Size GetPreferredSize(Size proposedSize)
        {
            return base.GetPreferredSize(new Size(this.Width, proposedSize.Height));
        }
    }

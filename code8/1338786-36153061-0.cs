    public class ComboBoxBasic : ComboBox
    {
        bool diffTextColor = false;
        public ComboBoxBasic()
        {
        }
        public object SelectedItemValue
        {
            get
            {
                return (SelectedItem as ComboBoxBasicDB).Value;
            }
            set
            {
                for(int i = 0; i < Items.Count; i++)
                {
                    ComboBoxBasicDB item = Items[i] as ComboBoxBasicDB;
                    if(item.Value.ToString() == value.ToString())
                    {
                        SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        public bool DifferentTextColor
        {
            get { return diffTextColor; }
            set
            {
                diffTextColor = value;
                if (diffTextColor)
                {
                    DrawItem += ComboBoxBasic_DrawItem;
                    DrawMode = DrawMode.OwnerDrawFixed;
                }
                else
                    DrawItem -= ComboBoxBasic_DrawItem;
            }
        }
        void ComboBoxBasic_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.State == DrawItemState.Focus)
                e.DrawFocusRectangle();
            Brush brush = new SolidBrush((sender as Control).ForeColor);
            ComboBoxBasicDB item = (sender as ComboBoxBasic).Items[e.Index] as ComboBoxBasicDB;
            if (item.ForeColor != Brushes.Black)
                brush = item.ForeColor;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            e.Graphics.DrawString(item.Text, (sender as Control).Font, brush, e.Bounds.X, e.Bounds.Y);
        }
    }

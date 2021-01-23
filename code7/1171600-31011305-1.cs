    public class MyCheckedListBox : CheckedListBox
    {
        private SolidBrush primaryColor = new SolidBrush(Color.White);
        private SolidBrush alternateColor = new SolidBrush(Color.LightGreen);
        [Browsable(true)]
        public Color PrimaryColor
        {
            get { return primaryColor.Color; }
            set { primaryColor.Color = value; }
        }
        [Browsable(true)]
        public Color AlternateColor
        {
            get { return alternateColor.Color; }
            set { alternateColor.Color = value; }
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (Items.Count <= 0)
                return;
            
            var contentRect = e.Bounds;
            contentRect.X = 16;
            e.Graphics.FillRectangle(e.Index%2 == 0 ? primaryColor : alternateColor, contentRect);
            e.Graphics.DrawString(Convert.ToString(Items[e.Index]), e.Font, Brushes.Black, contentRect);
        }
    }

    public delegate bool PreRemoveTab(int indx);
    public class TabControlEx : TabControl
    {
        public TabControlEx()
            : base()
        {
            PreRemoveTabPage = null;
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
        }
        public PreRemoveTab PreRemoveTabPage;
        protected const int size = 5;
        protected int moveRight = 0;
        protected int MoveRight
        {
            get { return moveRight; }
            set { moveRight = value; }
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Brush b = new SolidBrush(Color.Salmon);
            Brush b1 = new SolidBrush(Color.Black);
            Font f = this.Font;
            Font f1 = new Font("Arial", 9,FontStyle.Bold);
            if (e.Index != 0)
            {
                Rectangle r = e.Bounds;
                r = GetTabRect(e.Index);
                r.Offset(2, 2);
                r.Width = size;
                r.Height = size;               
                Pen p = new Pen(b,2);
                string title = this.TabPages[e.Index].Text;               
                string boldLetter = title.Substring(0, 1);
                title = title.Remove(0, 1);
                MoveRight = ((Int32)e.Graphics.MeasureString(title, f, 200).Width) + 1;   // -1
                e.Graphics.DrawLine(p, r.X +10 + MoveRight - 2, r.Y, r.X +10 + MoveRight + r.Width, r.Y + r.Height+2);
                e.Graphics.DrawLine(p, r.X +10 + MoveRight + r.Width, r.Y, r.X + 10 + MoveRight-2, r.Y + r.Height+2);
                e.Graphics.DrawString(boldLetter, f1, b1, new PointF(r.X, r.Y));
                e.Graphics.DrawString(title, f, b1, new PointF(r.X+8, r.Y+1));    
            }
            else
            {
                Rectangle r = GetTabRect(e.Index);
                e.Graphics.DrawString(this.TabPages[e.Index].Text, f, b1, new PointF(r.X + 5, r.Y));
            }
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            Point p = e.Location;
            for (int i = 0; i < TabCount; i++)
            {
                Rectangle r = GetTabRect(i);
                r.Offset(2, 2);
                r.Width = size+2;
                r.Height = size+2;
                r.X = r.X + MoveRight + 8;
                if (r.Contains(p))
                {
                    if (i != 0)
                    {
                        CloseTab(i);
                    }
                }
            }
        }
        private void CloseTab(int i)
        {
            if (PreRemoveTabPage != null)
            {
                bool closeIt = PreRemoveTabPage(i);
                if (!closeIt)
                    return;
            }
            TabPages.Remove(TabPages[i]);
        }
    }

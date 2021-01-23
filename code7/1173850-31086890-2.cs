    public partial class SplitTablePanel : TableLayoutPanel
    {
        public int SplitterSize { get; set; }
        int sizingRow = -1;
        int currentRow = -1;
        Point mdown = Point.Empty;
        int oldHeight = -1;
        bool isNormal = false;
        List<RectangleF> TlpRows = new List<RectangleF>();
        int[] rowHeights = new int[0];
        public SplitTablePanel()
        {
            InitializeComponent();
            this.MouseDown += SplitTablePanel_MouseDown;
            this.MouseMove += SplitTablePanel_MouseMove;
            this.MouseUp += SplitTablePanel_MouseUp;
            this.MouseLeave += SplitTablePanel_MouseLeave;
            SplitterSize = 6;
        }
        void SplitTablePanel_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        void SplitTablePanel_MouseUp(object sender, MouseEventArgs e)
        {
            getRowRectangles(SplitterSize);
        }
        void SplitTablePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isNormal) nomalizeRowStyles();
            if (TlpRows.Count <= 0) getRowRectangles(SplitterSize);
            if (rowHeights.Length <= 0) rowHeights = GetRowHeights();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (sizingRow < 0) return;
                int newHeight = oldHeight + e.Y - mdown.Y;
                sizeRow(sizingRow, newHeight);
            }
            else
            {
                currentRow = -1;
                for (int i = 0; i < TlpRows.Count; i++)
                    if (TlpRows[i].Contains(e.Location)) { currentRow = i; break;}
                Cursor = currentRow >= 0 ? Cursors.SizeNS : Cursors.Default;
            }
        }
        void SplitTablePanel_MouseDown(object sender, MouseEventArgs e)
        {
            mdown = Point.Empty;
            sizingRow = -1;
            if (currentRow < 0) return;
            sizingRow = currentRow;
            oldHeight = rowHeights[sizingRow];
            mdown = e.Location;
        }
        void getRowRectangles(float size)
        {   // get a list of mouse sensitive rectangles
            float sz = size / 2f;
            float y = 0f;
            int w = ClientSize.Width;
            int[] rw = GetRowHeights();
            TlpRows.Clear();
            for (int i = 0; i < rw.Length - 1; i++)
            {
                y += rw[i];
                TlpRows.Add(new RectangleF(0, y - sz, w, size));
            }
        }
        void sizeRow(int row, int newHeight)
        {   // change the height of one row
            if (newHeight == 0) return;
            if (sizingRow < 0) return;
            SuspendLayout();
            rowHeights = GetRowHeights();
            if (sizingRow >= rowHeights.Length) return;
            if (newHeight > 0) 
                RowStyles[sizingRow] = new RowStyle(SizeType.Absolute, newHeight);
            ResumeLayout();
            rowHeights = GetRowHeights();
            getRowRectangles(SplitterSize);
        }
        void nomalizeRowStyles()
        {   // set all rows to absolute and the last one to percent=100!
            if (rowHeights.Length <= 0) return;
            rowHeights = GetRowHeights();
            RowStyles.Clear();
            for (int i = 0; i < RowCount - 1; i++)
            {
                RowStyle cs = new RowStyle(SizeType.Absolute, rowHeights[i]);
                RowStyles.Add(cs);
            }
            RowStyles.Add ( new RowStyle(SizeType.Percent, 100) );
            isNormal = true;
        }
    }
    }

    public enum SeatState
    {
        Empty,
        Selected,
        Full
    }
    public partial class Seats : UserControl
    {
        private int _Columns;
        private int _Rows;
        private List<List<SeatState>> _SeatStates;
        public Seats()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _SeatStates = new List<List<SeatState>>();
            _Rows = 40;
            _Columns = 40;
            ReDimSeatStates();
            MouseUp += OnMouseUp;
            Paint += OnPaint;
            Resize += OnResize;
        }
        public int Columns
        {
            get { return _Columns; }
            set
            {
                _Columns = Math.Min(1, value);
                ReDimSeatStates();
            }
        }
        public int Rows
        {
            get { return _Rows; }
            set
            {
                _Rows = Math.Min(1, value);
                ReDimSeatStates();
            }
        }
        private Image GetPictureForSeat(int row, int column)
        {
            var seatState = _SeatStates[row][column];
            switch (seatState)
            {
                case SeatState.Empty:
                    return Properties.Resources.emptySeat;
                case SeatState.Selected:
                    return Properties.Resources.choosenSeat;
                default:
                case SeatState.Full:
                    return Properties.Resources.fullSeat;
            }
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            var heightPerSeat = Height / (float)Rows;
            var widthPerSeat = Width / (float)Columns;
            var row = (int)(e.X / widthPerSeat);
            var column = (int)(e.Y / heightPerSeat);
            var seatState = _SeatStates[row][column];
            switch (seatState)
            {
                case SeatState.Empty:
                    _SeatStates[row][column] = SeatState.Selected;
                    break;
                case SeatState.Selected:
                    _SeatStates[row][column] = SeatState.Empty;
                    break;
            }
            Invalidate();
        }
        private void OnPaint(object sender, PaintEventArgs e)
        {
            var heightPerSeat = Height / (float)Rows;
            var widthPerSeat = Width / (float)Columns;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    var seatImage = GetPictureForSeat(row, column);
                    e.Graphics.DrawImage(seatImage, row * widthPerSeat, column * heightPerSeat, widthPerSeat, heightPerSeat);
                }
            }
        }
        private void OnResize(object sender, System.EventArgs e)
        {
            Invalidate();
        }
        private void ReDimSeatStates()
        {
            while (_SeatStates.Count < Rows)
                _SeatStates.Add(new List<SeatState>());
            if (_SeatStates.First().Count < Columns)
                foreach (var columnList in _SeatStates)
                    while (columnList.Count < Columns)
                        columnList.Add(SeatState.Empty);
            while (_SeatStates.Count > Rows)
                _SeatStates.RemoveAt(_SeatStates.Count - 1);
            if (_SeatStates.First().Count > Columns)
                foreach (var columnList in _SeatStates)
                    while (columnList.Count > Columns)
                        columnList.RemoveAt(columnList.Count - 1);
        }
    }

    class ButtonPosition {
        public int TopLeftX { get; set; }
        public int TopLeftY { get; set; }
        public int BottomRightX {
            get { return TopLeftX + Width; }
        }
        public int BottomRightY {
            get { return TopLeftY + Height; }
        }
        public int Width { get; set; }
        public int Height { get; set; }
        public ButtonPosition(int topLeftX, int topLeftY, int width, int height) {
            TopLeftX = topLeftX;
            TopLeftY = topLeftY;
            Width = width;
            Height = height;
        }
        public bool Overlaps(ButtonPosition bp) {
            return (bp.TopLeftX < this.BottomRightX && bp.BottomRightX > this.TopLeftX && bp.TopLeftY < this.BottomRightY && bp.BottomRightY > this.TopLeftY);
        }
    }

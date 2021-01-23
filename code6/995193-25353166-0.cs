    class SnapWrapper
    {
        public WindowSnap windowSnap { get; set; }
        public Rectangle rect { get; set; }
        public Bitmap bitmap { get; set; }
        public SnapWrapper(WindowSnap windowSnap_) { windowSnap = windowSnap_; }
        public override string ToString() {  return windowSnap.ToString();  }
        public bool IsSet() { return rect != Rectangle.Empty; }
    }

    public class InterpolatingPictureBox : PictureBox
    {
        public InterpolationMode InterpolationMode { get; set; }
        protected override void OnPaint(PaintEventArgs eventArgs)
        {
            eventArgs.Graphics.InterpolationMode = InterpolationMode;
            base.OnPaint(eventArgs);
        }
    }

    public class OutlinedText : TextBlock
    {
        public OutlinedText()
        {
            LayoutUpdated += OutlinedText_LayoutUpdated;
        }
        void OutlinedText_LayoutUpdated(object sender, EventArgs e)
        {
            CreateText();
            //...
        }

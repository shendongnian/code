    public class OverlayControl : UserControl
    {
        private readonly CheckBox _checkBox = new CheckBox();
        private readonly TrackBar _trackBar = new TrackBar();
        public ToolStripExtended()
        {
            _checkBox.Text = "Overlay";
            BackColor = SystemColors.Window;
            _checkBox.AutoSize = true;
            _trackBar.AutoSize = true;
            var flowLayoutPanel = new FlowLayoutPanel {AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink};
            flowLayoutPanel.Controls.AddRange( new Control[] { _checkBox, _trackBar });
            Controls.Add(flowLayoutPanel);
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PerformLayout();
        }
    } 

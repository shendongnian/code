    public class ToolStripLabelTextBox : ToolStripControlHost {
    
    	public Label Label { get; private set; }
    	public TextBox TextBox { get; private set; }
    
    	public ToolStripLabelTextBox(String labelText) : base(new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, WrapContents = false, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, Padding = Padding.Empty, Margin = Padding.Empty }) {
    		Label = new Label { Text = labelText, AutoSize = true, Anchor = AnchorStyles.Top | AnchorStyles.Bottom, TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
    		TextBox = new TextBox();
    
    		FlowLayoutPanel panel = (FlowLayoutPanel) Control;
    		panel.Controls.Add(Label);
    		panel.Controls.Add(TextBox);
    	}
    }

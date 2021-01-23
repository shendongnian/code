    public class Form5 : Form {
    
    	CheckBox cbTopMost = new CheckBox { Text = "Top Most" };
    
    	public Form5() {
    		Controls.Add(cbTopMost);
    
    		cbTopMost.CheckedChanged += delegate {
    			this.TopMost = cbTopMost.Checked;
    		};
    	}
    }

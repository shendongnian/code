    class FormTab2 : Form {
    
    	public FormTab2() {
    		TabControl tc = new TC2 { Dock = DockStyle.Fill };
    		TabPage p1 = new TabPage() { Text = "Tab1" };
    		TabPage p2 = new TabPage() { Text = "Tab2" };
    		p1.Controls.Add(new Button { Text = "Button1" });
    		p2.Controls.Add(new Button { Text = "Button2" });
    		tc.TabPages.Add(p1);
    		tc.TabPages.Add(p2);
    		Controls.Add(tc);
    	}
    
    	public class TC2 : TabControl {
    
    		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
    			if (keyData == Keys.Tab && this.Focused) {
    				int x = (SelectedIndex + 1) % TabPages.Count;
    				SelectedTab = TabPages[x];
    				//this.Focus();
    				return true;
    			}
    			return base.ProcessCmdKey(ref msg, keyData);
    		}
    	}
    }

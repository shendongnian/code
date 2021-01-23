    public class Form5 : Form {
    
    	protected override void OnMouseDown(MouseEventArgs e) {
    		base.OnMouseDown(e);
    		if (wasMouseActivated) {
    			wasMouseActivated = false;
    			// window was activated by a mouse click
    		}
    		else {
    			// window already had focus
    		}
    	}
    
    	private const int WM_MOUSEACTIVATE = 0x21;
    	private bool wasMouseActivated = false;
    	protected override void WndProc(ref Message m) {
    		if (m.Msg == WM_MOUSEACTIVATE) {
    			wasMouseActivated = true;
    		}
    
    		base.WndProc(ref m);
    	}
    }

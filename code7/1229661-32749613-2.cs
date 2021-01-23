    public class MyForm3 : Form, IMessageFilter {
    
    	PropertyGrid pg = new MyPropertyGrid { Dock = DockStyle.Fill };
    	Control gridView = null;
    	MethodInfo miSplittlerInside = null;
    
    	public MyForm3() {
    		Controls.Add(pg);
    		pg.SelectedObject = new Button { Text = "Bob" };
    
    		var f = typeof(PropertyGrid).GetField("gridView", BindingFlags.Instance | BindingFlags.NonPublic);
    		gridView = (Control) f.GetValue(pg);
    		miSplittlerInside = gridView.GetType().GetMethod("SplitterInside", BindingFlags.Instance | BindingFlags.NonPublic);
    
    		Application.AddMessageFilter(this);
    	}
    
    	private const int WM_MOUSEMOVE = 0x200;
    	private const int WM_LBUTTONDOWN = 0x201;
    	private const int WM_LBUTTONDBLCLK = 0x203;
    
    	public bool PreFilterMessage(ref Message m) {
    		if (m.HWnd == gridView.Handle) {
    			if (m.Msg == WM_MOUSEMOVE || m.Msg == WM_LBUTTONDOWN || m.Msg == WM_LBUTTONDBLCLK) {
    				Point pt = new Point(m.LParam.ToInt32());
    				bool inside = (bool) miSplittlerInside.Invoke(gridView, new Object[] { pt.X, pt.Y });
    				if (inside) {
    					return true;
    				}
    			}
    		}
    		return false;
    	}
    
    	class MyPropertyGrid : PropertyGrid {
    		protected override void OnMouseMove(MouseEventArgs me) {
    			//base.OnMouseMove(me);
    			// do nothing, prevent user from moving the split bar
    		}
    
    		protected override void OnMouseDown(MouseEventArgs me) {
    			//base.OnMouseDown(me);
    		}
    	}
    }

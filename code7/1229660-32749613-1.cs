    public class MyForm3 : Form {
    
    	PropertyGrid pg = new MyPropertyGrid { Dock = DockStyle.Fill };
    
    	public MyForm3() {
    		Controls.Add(pg);
    		pg.SelectedObject = new Person { name = "Bob" };
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

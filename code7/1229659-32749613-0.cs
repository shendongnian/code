    class MyPropertyGrid : PropertyGrid {
    
    	protected override void OnMouseMove(MouseEventArgs me) {
    		//base.OnMouseMove(me);
    		// do nothing, prevent user from moving the split bar
    	}
    
    	protected override void OnMouseDown(MouseEventArgs me) {
    		//base.OnMouseDown(me);
    	}
    
    }

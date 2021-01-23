    public void OnGUI ()
    {
    var savedMatrix = GUI.matrix;
    scrollPosition = GUI.BeginScrollView (new Rect (10f, 10f, Screen.width - 10f, Screen.height - 10f), scrollPosition, new Rect (10f, 10f, Screen.width - 10f, (_files.Count + 2) * 200f));
    		if (Input.touchCount == 1) {
    			Vector2 touchDelta2 = Input.GetTouch (0).deltaPosition;
    			scrollPosition.y += touchDelta2.y;
    		}
    		var selected = GUILayout.SelectionGrid (gridInt, _files.ToArray (), 1, MyStyle);
    		if (selected >= 0) {
    			if (selected == 0) {
    				if (selectedItem != null )
    					if (selectedItem.Parent != null)
    						selectedItem = selectedItem.Parent;
    				else 
    					selectedItem = null;
    			} else {
    				SelectFolder (selected);
    			}
    			
    			RefreshViewModel ();
    		}
    		GUI.EndScrollView ();
    		GUI.matrix = savedMatrix;
    }

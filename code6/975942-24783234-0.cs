    		if (Input.GetKey(KeyCode.Return))
    		{
    			wasClicked = true;
    		}
    
    		if (wasClicked)
    		{
    			if (!Input.GetKey(KeyCode.Return))
    			{
    				GUI.FocusControl(null);
    				pageNum = next page number;
    				wasClicked = false;
    			}
    		}

    protected override bool ProcessCmdKey(ref Message message, Keys keys)
    {
    			switch (keys)
    			{
    				case Keys.A | Keys.Control:
    					// ... Process Shift+Ctrl+Alt+B ...
    					adding = true;
    					updating = false;
    					EnableText();
    					ClearText();
    					AutoNo();
    					return true; // signal that we've processed this key
    				case Keys.S | Keys.Control:
    					// ... Process Shift+Ctrl+Alt+B ...
    					SaveUpdate();
    					return true; // signal that we've processed this key
    				case Keys.E | Keys.Control:
    					// ... Process Shift+Ctrl+Alt+B ...
    					updating = true;
    					adding = false;
    					EnableText();
    					return true; // signal that we've processed this key
    				case Keys.D | Keys.Control:
    					// ... Process Shift+Ctrl+Alt+B ...
    					DeleteRecord();
    					return true; // signal that we've processed this key
    			}
    			// run base implementation
    			return base.ProcessCmdKey(ref message, keys);
    }

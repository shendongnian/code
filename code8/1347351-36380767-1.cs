    private static void Control_HandleCreated(object sender, EventArgs e) {
    	
    	InstanceControlHintFields();
    
    	Control ctrl = (Control)sender;
    	ControlHintInfo hintInfo = controlHintsB(ctrl);
    
    	SetProperties(ctrl, hintInfo);
    }
    
    private static void Control_Enter(object sender, EventArgs e) {
    	
    	InstanceControlHintFields();
    
    	Control ctrl = (Control)sender;
    	string ctrlText = ctrl.Text;
    	ControlHintInfo ctrlDefaults = controlHintsDefaults(ctrl);
    	ControlHintInfo hintInfo = controlHintsB(ctrl);
    
    	switch (hintInfo.HintType) {
    
    		case ControlHintType.Normal:
    			if ((ctrlText.Equals(hintInfo.Text, StringComparison.OrdinalIgnoreCase))) {
    				RestoreProperties(ctrl, ctrlDefaults);
    			}
    
    			break;
    	}
    }
    
    private static void Control_Leave(object sender, EventArgs e) {
    	
    	InstanceControlHintFields();
    
    	Control ctrl = (Control)sender;
    	string ctrlText = ctrl.Text;
    	ControlHintInfo ctrlDefaults = controlHintsDefaults(ctrl);
    	ControlHintInfo hintInfo = controlHintsB(ctrl);
    
    	switch (hintInfo.HintType) {
    
    		case ControlHintType.Normal:
    			if ((ctrlText.Equals(hintInfo.Text, StringComparison.OrdinalIgnoreCase))) {
    				RestoreProperties(ctrl, ctrlDefaults);
    
    			} else if (string.IsNullOrEmpty(ctrlText)) {
    				SetProperties(ctrl, hintInfo);
    
    			}
    
    			break;
    		case ControlHintType.Persistent:
    			if (string.IsNullOrEmpty(ctrlText)) {
    				SetProperties(ctrl, hintInfo);
    			}
    
    			break;
    	}
    }
    
    private static void Control_MouseDown(object sender, MouseEventArgs e) {
    	
    	InstanceControlHintFields();
    
    	Control ctrl = (Control)sender;
    	string ctrlText = ctrl.Text;
    	ControlHintInfo hintInfo = controlHintsB(ctrl);
    
    	switch (hintInfo.HintType) {
    
    		case ControlHintType.Persistent:
    
    
    			if ((ctrlText.Equals(hintInfo.Text, StringComparison.OrdinalIgnoreCase))) {
    				// Get the 'Select' control's method (if exist).
    				MethodInfo method = sender.GetType.GetMethod("Select", BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, {
    					typeof(int),
    					typeof(int)
    				}, null);
    
    				if ((method != null)) {
    					// Select the zero length.
    					method.Invoke(ctrl, new object[] {
    						0,
    						0
    					});
    				}
    
    			}
    
    			break;
    	}
    }
    
    private static void Control_KeyDown(object sender, KeyEventArgs e) {
    
    	Control ctrl = (Control)sender;
    	string ctrlText = ctrl.Text;
    	ControlHintInfo ctrlDefaults = controlHintsDefaults(ctrl);
    	ControlHintInfo hintInfo = controlHintsB(ctrl);
    
    	switch (hintInfo.HintType) {
    
    		case ControlHintType.Persistent:
    			if ((ctrlText.Equals(hintInfo.Text, StringComparison.OrdinalIgnoreCase))) {
    				RestoreProperties(ctrl, ctrlDefaults);
    
    			} else if (string.IsNullOrEmpty(ctrlText)) {
    				RestoreProperties(ctrl, ctrlDefaults, skipProperties: { "Text" });
    
    			}
    
    			break;
    		case ControlHintType.Normal:
    			if (string.IsNullOrEmpty(ctrlText)) {
    				RestoreProperties(ctrl, ctrlDefaults);
    			}
    
    			break;
    	}
    }
    
    private static void Control_Disposed(object sender, EventArgs e) {
    	RemoveHint((Control)sender);
    }

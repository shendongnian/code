    Control c1 = ...;
    Control c2 = ...;
    c1.EnabledChanged += delegate {
    	if (c1.Enabled)
    		c2.Enabled = true;
    };

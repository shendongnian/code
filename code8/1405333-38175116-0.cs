    		var k_LineC = guiVal.GetType().BaseType.GetField("k_LineHeight", BindingFlags.Instance | 
			BindingFlags.Static |
			BindingFlags.NonPublic |
			BindingFlags.Public).GetValue(guiVal);
		    Debug.Log (k_LineC + "\n"); // <-- returns 16

			SecRecord existingRec = new SecRecord (SecKind.GenericPassword) { 
				Service = Keychain.USER_SERVICE, 
				Label = Keychain.USER_LABEL 
			};
			var record = new SecRecord (SecKind.GenericPassword) {
				Service = Keychain.USER_SERVICE, 
				Label = Keychain.USER_LABEL, 
				Account = username,
				ValueData = NSData.FromString (password),
				Accessible = SecAccessible.Always
			};
			SecStatusCode code = SecKeyChain.Add (record);
			if (code == SecStatusCode.DuplicateItem) {
				code = SecKeyChain.Remove (existingRec);
				if (code == SecStatusCode.Success)
					code = SecKeyChain.Add (record);
			}

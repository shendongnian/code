	private void processValueNames(RegistryKey Key) { //function to process the valueNames for a given key
		string[] valuenames = Key.GetValueNames();
		if (valuenames == null || valuenames.Length <= 0) //has no values
			return;
		foreach (string valuename in valuenames) {
			object obj = Key.GetValue(valuename);
			if (obj != null)
				comboBox1.Items.Add(Key.Name + " " + valuename + " " + obj.ToString()); //assuming the output to be in comboBox1 in string type
		}
	}
	public void OutputRegKey(RegistryKey Key) {
		try {
			string[] subkeynames = Key.GetSubKeyNames(); //means deeper folder
			if (subkeynames == null || subkeynames.Length <= 0) { //has no more subkey, process
				processValueNames(Key);
				return;
			}
			foreach (string keyname in subkeynames) { //has subkeys, go deeper
				using (RegistryKey key2 = Key.OpenSubKey(keyname))
					OutputRegKey(key2);
			}
			processValueNames(Key); 
		} catch (Exception e) {
			//error, do something
		}
	}

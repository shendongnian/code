    FieldInfo[] helperFields = typeof(SaveLoadGameData).GetFields();
	FieldInfo[] defaults = typeof(Helper).GetFields(BindingFlags.Static | BindingFlags.Public);
	for(int i = 0; i < defaults.Length; i += 1)
	{
		Debug.Log(helperFields[i].Name + ", " + helperFields[i].GetValue(saveLoadObject) + ", " + defaults[i].GetValue(null));
		Assert.AreEqual(helperFields[i].GetValue(saveLoadObject), defaults[i].GetValue(null));
	}

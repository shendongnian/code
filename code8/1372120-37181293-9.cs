	/// <summary>
	/// Method that adds a new empty entry to all setting arrays.
	/// </summary>
	private static void AddEntryToSettingsArrays()
	{
		ArrayNamesList CurrentArrays = CreateArrayDictionary(); // Creates a list of the currently used setting arrays.
		GlobalVariables.FolderCount++; // Increments the folder count by one.
		foreach (string CurrentArray in CurrentArrays) // Loops through the list of arrays.
		{
			FieldInfo TempArrayField = typeof(GlobalVariables).GetField(CurrentArray); // Gets the current array with reflection.
			Array TempArray = (Array)TempArrayField.GetValue(typeof(GlobalVariables)); // Gets value of the current array.
			ArrayResize(ref TempArray, GlobalVariables.FolderCount); // Resizes the array.
			Type ArrayType = TempArray.GetType().GetElementType(); // Gets the type of the array.
			TempArrayField.SetValue(ArrayType, TempArray); // Replaces the old with the new array.
		}
	}

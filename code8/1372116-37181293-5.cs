	/// <summary>
	/// Method that removes a certain entry from all setting arrays.
	/// </summary>
	/// <param name="RemoveID">ID of the setting that should be removed from the settings.</param>
	private static void RemoveEntryFromSettingsArrays(int RemoveID)
	{
		ArrayNamesList CurrentArrays = CreateArrayDictionary(); // Creates a list of the currently used setting arrays.
		GlobalVariables.FolderCount--; // Decrements the folder count by one.
		foreach (string CurrentArray in CurrentArrays) // Loops through the list of arrays.
		{
			FieldInfo TempArrayField = typeof(GlobalVariables).GetField(CurrentArray);// Gets the current array with reflection.
			Array TempArray = (Array)TempArrayField.GetValue(typeof(GlobalVariables)); // Gets value of the current array.
			ArrayResize(ref TempArray, GlobalVariables.FolderCount, RemoveID); // Removes an ID from the array.
			Type ArrayType = TempArray.GetType().GetElementType(); // Gets the type of the array.
			TempArrayField.SetValue(ArrayType, TempArray); // Replaces the old with the new array.
		}
	}

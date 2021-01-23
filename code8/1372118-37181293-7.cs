	/// <summary>
	/// Method that creates a list of possible batch setting array names.
	/// </summary>
	/// <returns>Returns a list of possible batch setting array names.</returns>
	private static ArrayNamesList CreateArrayDictionary()
	{
		BatchArrayNamesList PossibleBatchArrays = new BatchArrayNamesList(); // Creates a new "Batch Array Names List".
		PossibleBatchArrays.Add(nameof(GlobalVariables.ArrayOne)); // Adds the setting "1" name to the List.
		PossibleBatchArrays.Add(nameof(GlobalVariables.ArrayTwo)); // Adds the setting "2" name to the List.
		// ...
		return PossibleBatchArrays;
	}

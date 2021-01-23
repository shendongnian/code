	/// <summary>
	/// Function that increases an array of unknown type to a certain length.
	/// </summary>
	/// <param name="CurrentArray">The array that needs to be increased in size.</param>
	/// <param name="NewArraySize">The new size of the array.</param>
	private static void ArrayResize(ref Array CurrentArray, int NewArraySize)
	{
		if (CurrentArray.Length < NewArraySize) // Checks if the new array size is larger than the old size.
		{
			Type elementType = CurrentArray.GetType().GetElementType(); // Gets the type of the arrays elements.
			Array newArray = Array.CreateInstance(elementType, NewArraySize); // Creats a new array with the new length.
			Array.Copy(CurrentArray, newArray, CurrentArray.Length); // Transfers the data from the old array to the new array.
			CurrentArray = newArray; // Replaces the old array with the new array.
		}
		else
		{
			Debugging.ErrorHandling.ErrorHandler("The new array size is not larger than the old array size.", 1201); // Creates an event log entry and error messagebox if application is run with gui.
		}
	}

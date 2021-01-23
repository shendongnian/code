	/// <summary>
	/// Function that removes an entry from an array of unknown type.
	/// </summary>
	/// <param name="CurrentArray">The array an entry needs to be deleted from.</param>
	/// <param name="NewArraySize">The new size of the array.</param>
	/// <param name="RemoveArrayID">The ID of the arrays entry that needs to be removed.</param>
	private static void ArrayResize(ref Array CurrentArray, int NewArraySize, int RemoveArrayID)
	{
		if
		(
			NewArraySize <= 0 // Checks if the new array size is not negative.
			&& (CurrentArray.Length - 1) == NewArraySize // And if the new array size is the same than the old array size minus one entry.
		)
		{
			Type elementType = CurrentArray.GetType().GetElementType(); // Gets the type of the arrays elements.
			Array newArray = Array.CreateInstance(elementType, NewArraySize);  // Creats a new array with the new length.
			if (NewArraySize != 0) // if the new array is not empty.
			{
				int PositionStart = RemoveArrayID + 1; // Calculates the the start position of the entrys behind the removed ID.
				int RemainingLength = newArray.Length - RemoveArrayID; // Calculates the length of the array behind the removed ID.
				if (RemoveArrayID > 0) // If the array ID that should be remove is not the first entry.
				{
					Array.Copy(CurrentArray, 0, newArray, 0, RemoveArrayID); // Copys the entrys in front of the removed ID in the new array.
				}
				else if (RemainingLength > 0) // If the array ID that should be remove is not the last entry.
				{
					Array.Copy(CurrentArray, PositionStart, newArray, RemoveArrayID, RemainingLength); // Copys the entrys behind the removed ID in the new array.
				}
			}
			CurrentArray = newArray; // Replaces the old array with the new array.
		}
		else
		{
			Debugging.ErrorHandling.ErrorHandler("The new array size has an negative value or is not one entry smaller that the old array size.", 1202); // Creates an event log entry and error messagebox if application is run with gui.
		}
	}

    public static class SaveStatesExtension
	{
		public static bool IsSavedState(this SaveStates state) {
			return state == SaveStates.SavedWithChanges || 
				   state == SaveStates.SavedWithoutChanges;
		}
	}

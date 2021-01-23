	private static class MemoryPressurePatcher
	{
		public static void Patch()
		{
			var memoryPressureType = typeof(Duration).Assembly.GetType("MS.Internal.MemoryPressure");
			var totalMemoryField = memoryPressureType?.GetField("_totalMemory", BindingFlags.Static | BindingFlags.NonPublic);
			if (totalMemoryField?.FieldType != typeof(long))
				return;
			var currentValue = (long) totalMemoryField.GetValue(null);
			totalMemoryField.SetValue(null, currentValue + long.MinValue);
		}
	}
	

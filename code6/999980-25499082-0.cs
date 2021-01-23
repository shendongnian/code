		private static void SetStatusLineValue(int value)
		{
			Console.SetCursorPosition(3, Console.CursorTop);
			Console.Write("\rStatus {0} Copied", value);
		}

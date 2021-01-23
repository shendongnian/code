        private string[] Sort(string[] input)
		{
			
			List<string> inputList = new List<string> ();
			inputList = input.ToList<string> ();
			List<string> sortedList = new List<string> ();
			string[] sort = new string[]{"Serial", "Width", "Height", "Active1", "Active2", "Time"};
			foreach(string key in sort)
			{
				if (inputList.Contains<string> (key)) {
					int i = inputList.IndexOf (key);
					sortedList.Add (inputList [i]);
					sortedList.Add (inputList [i + 1]);
					sortedList.Add (inputList [i + 2]);
				}
                else
                {
                    sortedList.Add (key);
                    sortedList.Add (null);
                    sortedList.Add (null);
                }
			}
			return sortedList.ToArray<string> ();
		}

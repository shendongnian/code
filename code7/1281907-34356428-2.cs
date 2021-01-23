			List<string> resultList = new List<string>();
			bool previousEmpty = false;
			foreach (string split in textWithStyle.Text.Split(new[] {Environment.NewLine, "\v"}, StringSplitOptions.None))
			{
				if (!string.IsNullOrEmpty(split))
					previousEmpty = false;
				else if (!previousEmpty)
				{
					previousEmpty = true;
					continue;
				}				
                
				resultList.Add(split);
			}
			string[] split = resultList.ToArray();

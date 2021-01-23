            List<string> AllCorrect = new List<string>();
            foreach (var item in ImportData)
            {
                if (item.Value == true && ItemsToCompare.Contains(item.Key))
                    AllCorrect.Add(item.Key);
            }
            AllCorrect.Sort();

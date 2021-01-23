            List<string> CopyString = new List<string>();
            CopyString.AddRange(listString);
            foreach (var item in CopyString)
            {
                var index = CopyString.IndexOf(item);
                if (index >= 0 && listString.Count(cnt => cnt == item) > 1)
                    listString.RemoveAt(index);
            }

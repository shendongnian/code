            var hashSet = new HashSet<string>();
            foreach (var obj in testList)
            {
                if (!hashSet.Add(obj.TestValue))
                {
                    obj.IsDuplicate = true;
                }
            }

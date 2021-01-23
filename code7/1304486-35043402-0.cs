            List<Foo> addedFoos = new List<Foo>();
            for (int i = 0; i < newFoos.Count; i++)
            {
                Foo current = newFoos[i];
                if (MyDict.ContainsKey(current.Id))
                {
                    addedFoos.Add(current);
                    //MyDict.Add(current.Id, current); /* see remark below */
                }
            }
            //addedFoos.ForEach(item => MyDict.Add(item.Id, item.Value)); /* see remark below */

            foreach (var list in rootList)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    var actor = list[i];
                    list[i] = new double[actor.Length + 1]; // all elements will be 0....
                    Array.Copy(list[i], actor, actor.Length); //just add the prev elements
                }
            }

            Proplist.Add(1, "test1");
            Proplist.Add(2, "test2");
            var first = Proplist.First();
            int key = first.Key;
            string Meassage = null;
            foreach (var current in Proplist)
            {
                if (first.Key == current.Key)
                {
                    //do only one
                }
                else
                {
                    Meassage = "edit:" + current.Key + "=" + current.Value;
                }
            }

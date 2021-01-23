            List<object> list = new List<object>();
            List<int> ints = new List<int>(); ints.Add(74); ints.Add(47);
            List<string> strings = new List<string>(); strings.Add("hello"); strings.Add("hello2");
            list.AddRange(ints.Cast<object>());
            list.AddRange(strings.Cast<object>());
            foreach (object o in list)
            {
                Trace.WriteLine(o);
                if (o is int)
                {
                    // do in specific stuff
                }
                // do all my generic stuff.    
            }

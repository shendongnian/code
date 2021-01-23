            int incrementalID = 0;
            Dictionary<int, string> list1 = new Dictionary<int, string>();
            Dictionary<int, string> list2 = new Dictionary<int, string>();
            list1.Add(incrementalID++, "dog");    //ID = 0
            list1.Add(incrementalID++, "cat");     //ID = 1
            list1.Add(incrementalID++, "fish");    //ID = 2
            list1.Add(incrementalID++, "cat");     //ID = 3
            list1.Add(incrementalID++, "cat");     //ID = 4
            list1.Add(incrementalID++, "mouse");   //ID = 5
            list2 = new Dictionary<int, string>(list1);
            list2.Remove(0);
            list2.Remove(1);
            list2.Add(incrementalID++, "cat");      //ID = 6
            list2.Add(incrementalID++, "hamster");  //ID = 7;
            Console.WriteLine("List 1" + Environment.NewLine);
            foreach (string item in list1.Values)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(Environment.NewLine + "List 2" + Environment.NewLine);
            foreach (string item in list2.Values)
            {
                Console.WriteLine(item);
            }
            var newItems = list2.Except(list1);
            Console.WriteLine(Environment.NewLine + "New Items" + Environment.NewLine);
            foreach (KeyValuePair<int, string> item in newItems)
            {
                Console.WriteLine(item.Value);
            }

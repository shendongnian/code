     public class FriendList
            {
                public List<string> friends { get; set; } // List of friends names
                public DateTime timestamp { get; set; } // date/time on the data file
            }
    
            public static Tuple<T, T> GetTwoBiggest<T>(IEnumerable<T> array, Comparison<T> comp)
            {
                var enumerator = array.GetEnumerator();
    
                if (!enumerator.MoveNext()) { throw new ArgumentException("We need collection with at least two items"); }
                T max1 = enumerator.Current;
    
                if (!enumerator.MoveNext()) { throw new ArgumentException("We need collection with at least two items"); }
                T max2 = enumerator.Current;
    
                if (comp(max1, max2) < 0)
                {
                    T tmp = max1;
                    max1 = max2;
                    max2 = tmp;
                }
    
                while (enumerator.MoveNext())
                {
                    T actual = enumerator.Current;
                    if (comp(actual, max1) >= 0)
                    {
                        max2 = max1;
                        max1 = actual;
                    }
                    else if (comp(actual, max2) > 0)
                    {
                        max2 = actual;
                    }
                }
    
                return new Tuple<T, T>(max1, max2);
            }
    
            private void button6_Click(object sender, EventArgs e)
            {
                List<FriendList> list = new List<FriendList>()
                {
                    new FriendList() { timestamp = new DateTime(2015,1,1) },
                    new FriendList() { timestamp = new DateTime(2015,10,2) },
                    new FriendList() { timestamp = new DateTime(2015,5,3) },
                    new FriendList() { timestamp = new DateTime(2015,2,4) },
                    new FriendList() { timestamp = new DateTime(2015,3,5) },
                    new FriendList() { timestamp = new DateTime(2015,7,6) },
                    new FriendList() { timestamp = new DateTime(2015,11,7) },
                    new FriendList() { timestamp = new DateTime(2015,8,8) },
                };
    
                var twoBiggest = GetTwoBiggest(list, (a, b) => a.timestamp.CompareTo(b.timestamp));
    
                Console.WriteLine(twoBiggest.Item1.timestamp);
                Console.WriteLine(twoBiggest.Item2.timestamp);
            }

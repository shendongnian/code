    class Program {
        delegate IEnumerable<T> FilterDelegate<T>(IEnumerable<T> collection) where T : class, INumericValue;
        delegate T SelectDelegate<T>(IEnumerable<T> collection, ref T previous) where T : class, INumericValue;
        delegate T CombinedDelegate<T>(IEnumerable<T> collection, ref T previous) where T : class, INumericValue;
        static void Main() {
            Test previous = new Test(6);
            List<Test> collection = new List<Test>();
            FilterDelegate<Test> filter = Filter;
            SelectDelegate<Test> select = Select;
            for (int i = 0; i < 10; i++)
                collection.Add(new Test(i));
            // use explicit types to be able to use ref in lambda
            CombinedDelegate<Test> combined = (IEnumerable<Test> c, ref Test p) => @select(filter(c), ref p);
            Test result = combined(collection, ref previous);
            //Expected result Test with Number = 7
        }
        static IEnumerable<T> Filter<T>(IEnumerable<T> collection) where T : class, INumericValue {
            return collection.Where(c => c.Number > 3);
        }
        static T Select<T>(IEnumerable<T> collection, ref T previous) where T : class, INumericValue {
            // this didn't compile so I changed it.
            foreach (var item in collection) {
                if (item.Number > previous.Number) {
                    previous = item;
                    break;
                }
            }
            return previous;
        }
    }

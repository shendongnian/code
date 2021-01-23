        static IEnumerable<T[]> CartesianProduct<T>(IList<IList<T>> collections) {
            // this contains the indexes of elements from each collection to combine next
            var indexes = new int[collections.Count];
            bool done = false;
            while (!done) {
                // initialize array for next combination
                var nextProduct = new T[collections.Count];
                // fill it
                for (int i = 0; i < collections.Count; i++) {
                    var collection = collections[i];
                    nextProduct[i] = collection[indexes[i]];
                }
                yield return nextProduct;
                // now we need to calculate indexes for the next combination
                // for that, increase last index by one, until it becomes equal to the length of last collection
                // then increase second last index by one until it becomes equal to the length of second last collection
                // and so on - basically the same how you would do with regular numbers - 09 + 1 = 10, 099 + 1 = 100 and so on.
                var j = collections.Count - 1;
                while (true) {
                    indexes[j]++;
                    if (indexes[j] < collections[j].Count) {
                        break;
                    }
                    indexes[j] = 0;
                    j--;
                    if (j < 0) {
                        done = true;
                        break;
                    }
                }
            }
        }

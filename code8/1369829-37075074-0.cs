        private static IEnumerable<T> CreateEnumerable<T>(IEnumerable<T> enumerable)
        {
            // Validate parameters.
            if (enumerable == null) throw new ArgumentNullException("enumerable");
            // Cycle through and yield.
            foreach (T t in enumerable)
                yield return t;
        }
        private static void EnumerateAndPrintResults<T>(IEnumerable<T> data,
            [CallerMemberName] string name = "")
            where T : IComparable<T>
        {
            // Write the name.
            Debug.WriteLine("Case: " + name);
            // Cycle through the chunks.
            foreach (IEnumerable<T> chunk in data.
                ChunkWhenNextSequenceElementIsNotGreater())
            {
                // Print opening brackets.
                Debug.Write("{ ");
                // Is this the first iteration?
                bool firstIteration = true;
                // Print the items.
                foreach (T t in chunk)
                {
                    // If not the first iteration, write
                    // a comma.
                    if (!firstIteration)
                    {
                        // Write the coma.
                        Debug.Write(", ");
                    }
                    // Write the item.
                    Debug.Write(t);
                    // Flip the flag.
                    firstIteration = false;
                }
                // Write the closing bracket.
                Debug.WriteLine(" }");
            }
        }
    }

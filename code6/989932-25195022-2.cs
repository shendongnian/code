    public static class VisualTreeSearch
    {
        /// <summary>
        /// Finds all elements of the specified type in the <see cref="System.Windows.DependencyObject"/>'s visual tree using a breadth-first search.
        /// </summary>
        /// <typeparam name="T">The type of element to search for.</typeparam>
        /// <param name="root">The object to search in.</param>
        /// <returns>A list of elements that match the criteria.</returns>
        public static IEnumerable<T> Find<T>(this DependencyObject root) where T : DependencyObject
        {
            return root.Find<T>(false, true);
        }
        /// <summary>
        /// Finds all elements of the specified type in the <see cref="System.Windows.DependencyObject"/>'s visual tree.
        /// </summary>
        /// <typeparam name="T">The type of element to search for.</typeparam>
        /// <param name="root">The object to search in.</param>
        /// <param name="depthFirst">True to do a depth-first search; false to do a breadth-first search</param>
        /// <param name="includeRoot">True to include the root element in the search; false to exclude it</param>
        /// <returns>A list of elements that match the criteria.</returns>
        public static IEnumerable<T> Find<T>(this DependencyObject root, bool depthFirst, bool includeRoot) where T : DependencyObject
        {
            if (includeRoot)
            {
                var depRoot = root as T;
                if (depRoot != null)
                    yield return depRoot;
            }
            var searchObjects = new LinkedList<DependencyObject>();
            searchObjects.AddFirst(root);
            while (searchObjects.First != null)
            {
                var parent = searchObjects.First.Value;
                var count = VisualTreeHelper.GetChildrenCount(parent);
                var insertAfterNode = depthFirst ? searchObjects.First : searchObjects.Last;
                for (int i = 0; i < count; i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                    var depChild = child as T;
                    if (depChild != null)
                        yield return depChild;
                    insertAfterNode = searchObjects.AddAfter(insertAfterNode, child);
                }
                searchObjects.RemoveFirst();
            }
        }
    }

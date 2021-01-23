    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        public sealed class Node<T>
        {
            public Node(T value) { Value = value; }
            public T Value { get; }
            public IEnumerable<Node<T>> Children => _children;
            public void Add(Node<T> child)
            {
                _children.Add(child);
            }
            readonly List<Node<T>> _children = new List<Node<T>>();
        }
        class Program
        {
            static void Main()
            {
                var root = makeTree(1, 1, 4, 5);
                lookFor(root, "3.4");
                lookFor(root, "6.3");
            }
            static void lookFor<T>(Node<T> root, T target) where T: IEquatable<T>
            {
                var found = Find(root, target);
                Console.WriteLine(found != null ? $"Found {target}" : $"Did not find {target}");
            }
            public static Node<T> Find<T>(Node<T> root, T target) where T: IEquatable<T>
            {
                if (root.Value != null && root.Value.Equals(target))
                    return root;
                foreach (var child in root.Children)
                {
                    var found = Find(child, target);
                    if (found != null)
                        return found;
                }
                return null;
            }
            static Node<string> makeTree(int id1, int id2, int depth, int nChildren)
            {
                var root = new Node<string>($"{id1}.{id2}");
                if (depth == 0)
                    return root;
                for (int i = 0; i < nChildren; ++i)
                    root.Add(makeTree(id1+1, i+1, depth-1, nChildren));
                return root;
            }
        }
    }

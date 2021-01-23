        private static void TestBST()
        {
            var bst = new BST();
            Node root = new Node(23);
            bst.addNode(13, root);
            bst.addNode(-12, root);
            bst.addNode(1, root);
            Debug.Assert(Enumerable.SequenceEqual(root.ToList(), new int[] { -12, 1, 13, 23 }));
        }

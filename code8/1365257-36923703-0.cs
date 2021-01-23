     public void Remove(TreeNode root, TreeNode Delete) {
            if (Data == null) {
               return null;
            }
            if (Delete.Data.CompareTo(root.Data) < 0) {
                root.nodeLeft = (root.nodeLeft.Remove(root.nodeLeft, Delete));
                return root;
            }
            ... and so on.

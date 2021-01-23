    using System.Collections.Generic;
    using System.Linq;
    public class TreeNode
    {
       public int val;
       public TreeNode left;
       public TreeNode right;
       public TreeNode(int x) { val = x; }
    }
    public class Solution
    {
       public IEnumerable<int> PreorderTraversal(TreeNode root)
       {
            if (root == null)
            {
                return Enumerable.Empty<int>();
            }
            else
            {
                IEnumerable<int> ret = new List<int> { root.val };
                ret = ret.Concat(PreorderTraversal(root.left));
                ret = ret.Concat(PreorderTraversal(root.right));
                return ret;
            }
        }
    }
     class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(42);
            root.right = new TreeNode(99);
            var result = new Solution().PreorderTraversal(root);
        }
    }

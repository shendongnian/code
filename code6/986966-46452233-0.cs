    public class Calculator
    {
        public int CountAllLeafsOn(List<Tree> trees, string сolor = null)
        {
            // Count the leafs (all from all branches of all trees, or only if they are colored with the provided color)
            return сolor == null 
                ? trees.Sum(tree => tree.Branches.Sum(branch => branch.Leaves.Count)) 
                : trees.Sum(tree => tree.Branches.Sum(branch => branch.Leaves.Count(leaf => leaf.Color.Equals(сolor))));
        }
    }
    
    public class Tree
    {
        public List<Branch> Branches { get; set; }
    }
    
    public class Branch
    {
        public List<Leaf> Leaves { get; set; }
    }
    
    public class Leaf
    {
        public string Color { get; set; }
    }

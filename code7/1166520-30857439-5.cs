    public class Tree<T> {
        public T Data { get; private set; }
        public Tree<T> Left { get; private set; }
        public Tree<T> Right { get; private set; }
    
        public Tree(T data, Tree<T> left, Tree<T> right)
        {
            this.Data = data;
            this.Left = left;
            this.Right = right;
        }
    }
    
    public struct Triple<T> {
        public T Result;
        public Nullable<T> LeftSeed;
        public Nullable<T> RightSeed;
    }
    
    public static Tree<T> Unfold<T>(Func<T, Triple<T>> water, T seed)
    {
        Triple<T> tmp = water(seed);
        Tree<T> leftTree =
            tmp.LeftSeed.HasValue ? Unfold<T>(water, tmp.LeftSeed.Value) : null;
        Tree<T> rightTree =
            tmp.RightSeed.HasValue ? Unfold<T>(water, tmp.RightSeed.Value) : null;
        return new Tree(tmp.Result, leftTree, rightTree);
    }

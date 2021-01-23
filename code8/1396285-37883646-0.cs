        interface INode<TParentType, TChildType>: IRoot<TChildType>, ILeaf<TParentType>
        {
        }
        interface IRoot<TChildType>
        {
            List<TChildType> Children { get; }            
        }
        interface ILeaf<TParentType>
        {
            TParentType Parent { get; }            
        }
        class FirstLevel : IRoot<SecondLevel> 
        {
            public List<SecondLevel> Children { get; set; }
        }
        class SecondLevel : INode<FirstLevel, ThirdLevel>
        {
            public List<ThirdLevel> Children { get; set; }
            public FirstLevel Parent { get; set; }
        }
        class ThirdLevel : INode<SecondLevel, FourthLevel>
        {
            public List<FourthLevel> Children { get; set; }
            public SecondLevel Parent { get; set; }
        }
        class FourthLevel : ILeaf<ThirdLevel>
        {
            public ThirdLevel Parent { get; set; }
        }

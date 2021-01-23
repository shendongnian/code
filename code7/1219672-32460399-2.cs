    class MyFragment
    {
        public TransformationBlock<SomeMessage,SomeOther> Input {get;}
        public Task Completion {get;}
        ActionBlock<SomeOther> _finalBlock;
        public MyFragment()
        {
            Input=new TransformationBlock<SomeMessage,SomeOther>(MyFunction);
            _finalBlock=new ActionBlock<SomeOther>(MyMethod);
            var linkOptions = new DataflowLinkOptions {PropagateCompletion = true}
            Input.LinkTo(_finalBlock,linkOptions);
        }
        private SomeOther MyFunction(SomeMessage msg)
        {
        ...
        }
        private void MyMethod(SomeOther msg)
        {
        ...
        }
    }

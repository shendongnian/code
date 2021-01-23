    public Tree()
    {
        var chunk2 = new Chunk();
        chunk2.OnTrigger += Hello; // OK: will be called
        chunk2.leaf.OnTrigger = (Action)chunk2.OnTrigger.Clone();
        chunk2.OnTrigger += World; // NOT: not be called
        chunk2.leaf.Go();
    }

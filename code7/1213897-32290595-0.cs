    public void Undo()
    {
        if(stack.Count > 0 ) stack.Pop();
        total = stack.Peek();
    }

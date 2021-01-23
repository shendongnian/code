    public static int maxElement(Stack<int> stack)
    {
        stack = new Stack<int>(stack); // Now changes will be local
    
        int max = stack.Peek();
        for (int i = 0; i < stack.Count; i++)
        {
            if (max >= stack.Peek())
            {
                stack.Pop();
            }
            else if (max < stack.Peek())
            {
                max = stack.Pop();
            }
        }
        return max;
    }

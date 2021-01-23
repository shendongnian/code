    static public List<Item> Parse(string str)
    {
        Stack<Item> stack = new Stack<Item>();
        Item root = new Item();
        stack.Push(root);
        foreach (char c in str)
        {
            if (char.IsLetter(c))
            {
                Item item = new Item();
                item.Name = c.ToString();
                stack.Peek().Children.Add(item);
                stack.Push(item);
            }
            else if (c == ')' || c == ',')
            {
                stack.Pop();
            }
        }
        return root.Children;
    }

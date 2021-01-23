    public void Delete(string value)
    {
        if (head == null) return;
        if (head.Value == value)
        {
            head = head.Next;
            return;
        }
        var n = head;
        while (n.Next != null)
        {
            if (n.Next.Value == value)
            {
                n.Next = n.Next.Next;
                return;
            }
            n = n.Next;
        }
    }

    public int Foo(int input)
    {
        if (input >= 0)
        {
            return input;
        }
        else if (input < 0)
        {
            return -input;
        }
        // This is still reachable...
    }

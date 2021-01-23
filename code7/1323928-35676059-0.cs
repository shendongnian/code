    int GetPlaceholderContent(int segment, int placeholder)
    {
        System.Random random = new System.Random(segment * 1024 + placeholder);
        return random.Next(0, 4);
    }
    void FillPlaceholder(int segment, int placeholder)
    {
        switch (GetPlaceholderContent(segment, placeholder))
        {
            case 0: /* FillWithNothing */ break;
            case 1: /* FillWithDecoration */ break;
            case 2: /* FillWithItem */ break;
            case 3: /* FillWithMonster */ break;
        }
    }

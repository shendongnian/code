    foreach (Base entry in objects)
    {
        switch (entry.GetType().Name)
        {
            case (nameof(ClassOne)):
                // Do something
                break;
            case (nameof(ClassTwo)):
                // Do something else
                break;
        }
    }

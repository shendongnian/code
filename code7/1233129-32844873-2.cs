    int x = GetUserInput();
    try
    {
        MustAcceptPositiveInput(x);
    }
    catch (InputIsNonPositiveException)
    {
        MustAcceptNonPositiveInput(x);
    }

    private bool saved;
    private bool withChanges;
    public void SomeMethod()
    {
        if (saved)
        {
            Console.WriteLine("Saved");
            if (withChanges)
            {
                Console.WriteLine("With Changes");
            }
            else
            {
                Console.WriteLine("Without Changes");
            }
        }
        else
        {
            Console.WriteLine("Not saved");
        }
    }

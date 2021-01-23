    private async Task callingMethod()
    {
        await getgoogleplususerdataSer(); // wait for this to end, then continue.
        Console.WriteLine(gName); // null
        Console.WriteLine(gEmail); // null
    }

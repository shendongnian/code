    public static void TestCodeContract(int value)
    {
        Contract.Requires(value > 100 && value < 110);
        // You could alternatively write two Contract.Requires statements as the blog
        // author originally did.
    }

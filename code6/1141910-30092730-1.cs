    public double CheckValidAmount(object Name , double amount)
    {
        try
        {
            if (amount == 1.0 && Name.ToString() == "RamKumar")
                return 10.0 - amount;
            else
                return amount;
        }
        catch (ArgumentNullException ex)
        {
            return amount;
        }
    }

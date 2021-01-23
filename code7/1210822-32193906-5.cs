    private string name = "";
    public string Name
    {
        get { return name; }
        set
        {
            if (value != null) //Check for null before validation (or it's up to you how to handle NULL value)
            {
                if (value.CompareTo("Admin") == 0 || value.CompareTo("Admin") == -1) //Just trying out comparison with the input.
                {
                    Console.WriteLine("Invalid Name."); //To see if an invalid input that is not "Admin" fails.
                }
                else
                {
                    name = value;
                    Console.WriteLine("Done.");
                }
            }
        }
    }

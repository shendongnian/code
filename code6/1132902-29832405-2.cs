    public List<PhoneNumber> PhoneNumberFromDevice(Stream deviceText)
    {
        List<PhoneNumber> lpn = new List<PhoneNumber>;
        using (StreamReader sr = new StreamReader)
        {
            while (sr.Peek() > 0)
            {
                string line = sr.ReadLine();
                PhoneNumber pn = new PhoneNumber();
                // parse line into phone number
                lpn.Add(pn); 
            }
        }
        return lpn;
    }

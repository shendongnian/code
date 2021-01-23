    List<IPAddress> addresses = new List<IPAddress>();
    foreach (string input in this.textBox1.Lines)
    {
        IPAddress ip;
        if (IPAddress.TryParse(input, out ip))
        {
            addresses.Add(ip);
        }
        else
        {
            Console.WriteLine("Input malformed: {0}", input);
        }
    }

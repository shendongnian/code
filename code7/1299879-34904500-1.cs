    string line;
    System.IO.StreamReader file = new System.IO.StreamReader(filePath);
    while ((line = file.ReadLine()) != null)
    {
        string[] parts = line.Split('-');
        float x = float.Parse(parts[0].Trim(), NumberFormatInfo.InvariantInfo);
		float y = float.Parse(parts[1].Trim(), NumberFormatInfo.InvariantInfo);
		DateTime d = DateTime.Parse(parts[2].Trim(), DateTimeFormatInfo.InvariantInfo);
        Console.WriteLine("X: {0}, Y: {1}, D: {2}", x, y, d);
    }

    using (StreamReader input = File.OpenText(txt_file_name))
    {
        using (StreamWriter output = File.CreateText(csv_file_name))
        {
            string date = input.ReadLine();
            string time = input.ReadLine();
            string random = input.ReadLine();
            output.WriteLine("{0};{1};{2}", date, time, random);
        }
    }

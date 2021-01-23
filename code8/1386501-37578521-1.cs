    using (var input = File.OpenText(txt_file_name))
    {
        using (var output = File.CreateText(csv_file_name))
        {
            var date = input.ReadLine();
            var time = input.ReadLine();
            var random = input.ReadLine();
            output.WriteLine("{0};{1};{2}", date, time, random);
        }
    }

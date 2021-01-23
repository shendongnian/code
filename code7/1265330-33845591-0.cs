        while (line != null)
        {
            line = myReader.ReadLine();
            if (line != null)
            {
                int temp;
                if (int.TryParse(line, out temp) && (temp % 2 == 0))
                {
                    Console.WriteLine(line);
                }
            }
        }

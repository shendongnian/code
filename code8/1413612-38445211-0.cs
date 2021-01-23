    string line;
        while ((line = sReader.ReadLine()) != null)
        {
            if (line.Contains("id: " + id2))
            {
                Console.WriteLine(line);
                break;
            }
            else if ((line = sReader.ReadLine()) == null)
            {
                Console.WriteLine("Worker not found with id " + id2);
            }
         }

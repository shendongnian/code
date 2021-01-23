    string line = "";
    int position = 0; //needed to set the array position
    while (line != null)
    {
        line = myReader.ReadLine();
        if (line != null)
        {
            Console.WriteLine(line);
            hoursArray[position] = int.Parse(line); //convert line to int and sotres it in the array
            position++;
        }
    }

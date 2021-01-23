    while ((line = streamReader.ReadLine()) != null)
    {
        int lastPos = 0;
        for (int index = 0; index <= line.Length; index++)
        {
            if (index == line.Length || line[index] == ' ')
            {
                if (lastPos < index)
                {
                    string word = line.Substring(lastPos, index - lastPos);
                    // process word here
                }
                lastPos = index + 1;
            }
        }
    }

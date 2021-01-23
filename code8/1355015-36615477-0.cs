    string toAcronym(string sentence)
    {
        string acronym = "";
        bool wasSpace = true;
        for (int i = 0; i < sentence.length(); i++)
        {
            if (wasSpace == true)
            {
                if (sentence[i] != ' ')
                {
                    wasSpace = false;
                    acronym += sentence[i];
                }
                else
                {
                    wasSpace = true; 
                }
            }
            else if (sentence[i] == ' ')
            {
                wasSpace = true;
            }
        }
        return acronym;
    }

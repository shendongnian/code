    for (int i = 0; i < ListA.Count(); i++)
    {
        bool found = false;
        for (int j = 0; j < ListB.Count(); j++)
        {
            DateTime aItem = DateTime.ParseExact(ListA[i], "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime bItem = DateTime.ParseExact(ListB[j], "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        
            if (aItem.ToString("HH:mm") == bItem.ToString("HH:mm"))
            {
                  if (!found)
                  {
                      Console.WriteLine("{0}    {1}", ListA[i], ListB[j]);
                      found = true;
                  }
                  else
                      Console.WriteLine(ListA[i]);
            }
        }
    }

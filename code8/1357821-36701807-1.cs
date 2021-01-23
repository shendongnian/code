    int[] numbersTwo = new int[10];
  
    while ((line = sr.ReadLine()) != null)
        {
            if (line != null)
            {
                string[] detailsArray = line.Split(',');
                for (int i = 0; i < detailsArray.Length; i++)
                {                
                    numbersTwo[i] = Convert.ToInt32(detailsArray[i]);
                }
            }
        }

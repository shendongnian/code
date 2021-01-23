    while ((line = sr.ReadLine()) != null)
        {
            if (line != null)
            {
                string[] detailsArray = line.Split(',');
                for (int i = 0; i < detailsArray.Length; i++)
                {                
                    numbersTwo[i] = int.Parse(detailsArray[i]);
                }
            }
        }

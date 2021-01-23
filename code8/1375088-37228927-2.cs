    static IEnumerable<string> GetGreetings()
    {
        Random generator = new Random();
        while (true)
        {
            int totalWeight = contentOptions.Sum(x => x.Weight);
            int selection = generator.Next(0, totalWeight);
            foreach (ContentModel model in contentOptions)
            {
                if (selection - model.Weight > 0)
                    selection -= model.Weight;
                else
                {
                    yield return model.Content;
                    break;
                }
            }
         }
    }

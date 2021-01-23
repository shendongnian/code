    public static List<Item> BestCombination(List<Item> items, int maxPrice, int maxCount)
    {
        var scores = new int[items.Count + 1, maxPrice + 1, maxCount + 1];
    
        for (int i = 1; i <= items.Count; i++)
        {
            var item = items[i - 1];
            for (int count = 1; count <= Math.Min(maxCount, i); count++)
            { 
                for (int price = 0; price <= maxPrice; price++)
                {                    
                    if (item.Price > price)
                        scores[i, price, count] = scores[i - 1, price, count];                
                    else
                        scores[i, price, count] = Math.Max(
                            scores[i - 1, price, count],
                            scores[i - 1, price - item.Price, count - 1] + item.Score);
                }
            }
        }
    
        var choosen = new List<Item>();
        int j = maxPrice;
        int k = maxCount;
        for (int i = items.Count; i > 0; i--)
        {
            var item = items[i - 1];
            if (scores[i, j, k] != scores[i - 1, j, k])
            {
                choosen.Add(item);
                j -= item.Price;
                k--;
            }
        }            
                    
        return choosen;
    }
    

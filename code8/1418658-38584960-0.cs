        try
        {
            int key;
            Dictionary<int, int> dict = new Dictionary<int, int>()
            {
                {1, 2},
                {2,3}
            };
            var x = (from y in dict
                     select new
                     {
                         value = dict[4]
                     }).ToList();
        }
        catch (KeyNotFoundException ex)
        {
             //key that is not there
        }
        catch (Exception ex)
        {
        }

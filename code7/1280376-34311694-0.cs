    List<ResultsList> items = Results.OrderByDescending(item1 => 
            item1.Set).ThenByDescending(item2 => item2.Figure1).ThenByDescending(item3 =>
                item3.Figure2).ToList();
            ResultsList winner = items[0];
            List<int> winners = new List<int>();
            winners.Add(winner.PlayerID);
            winners.AddRange(items.Where((item, index) => 
                index > 0 && item.Set == winner.Set && 
                item.Figure1 == winner.Figure1 && 
                item.Figure2 == winner.Figure2)
                .ToList().Select(item=>item.PlayerID));

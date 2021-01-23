        using (var results = await context.Users.Indexes.ListAsync())
        {
            while (await results.MoveNextAsync())
            {
                foreach (var current in results.Current)
                {
                    System.Diagnostics.Debug.WriteLine(current["name"].AsString);
                }
            }
        }

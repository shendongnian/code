    List<IdXYZ> newList = Points
            .Select(item => new IdXYZ
            {
                X = item.X,
                Y = item.Y,
                Z = item.Z % 2 == 0 || item.Z % 100 == 0 ? item.Z - 505 : item.Z - 405;
            })
            .ToList();

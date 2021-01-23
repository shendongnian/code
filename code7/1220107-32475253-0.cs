        AllCorrect.Sort(StringComparer.InvariantCultureIgnoreCase);
        var AllCorrectInfo = string.Join(", ", AllCorrect.ToArray());
        foreach (var DrawItem in AllDrawings)
        {
            
            DrawItem.Value.Sort();
            var DrawItemInfo = string.Join(", ", DrawItem.Value.ToArray());
             
            var match = AllCorrect.SequenceEqual(DrawItem.Value, StringComparer.InvariantCultureIgnoreCase);
            if (match == true)
            {
                FinalDrawing = DrawItem.Key;
            }
        }

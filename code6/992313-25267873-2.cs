    List<string> chunks = 
        comment
            // for each character in the string, project a new item containing the 
            // character itself and its index in the string
            .Select((ch, idx) => new { Character = ch, Index = idx })
            // Group the characters by their "divisibility" by 250
            .GroupBy(
                item => item.Index / 250, 
                item => item.Character, 
                // Make the result of the GroupBy a string of the grouped characters
                (idx, grp) => new string(grp.ToArray()))
            .ToList();

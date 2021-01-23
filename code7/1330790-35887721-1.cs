        private Color GetRandomColorOfLoist(int index)
        {
            Color possibleColor;
            if (selectedColors.Count < 4)
            {
                possibleColor = possibleColors[random.Next(0, possibleColors.Count)];
                selectedColors.Add(possibleColor);
                return possibleColor;
            }
            possibleColor = possibleColors[random.Next(0, possibleColors.Count)];
            while (possibleColor == selectedColors[index])
            {
                possibleColor = possibleColors[random.Next(0, possibleColors.Count)];
            }
            selectedColors[index] = possibleColor;
            return possibleColor;
        }

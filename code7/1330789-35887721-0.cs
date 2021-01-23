        private List<Color> selectedColors;
        private Color GetRandomColorOfLoist(Boolean newGame)
        {
            Color possibleColor;
            if (newGame)
            {
                selectedColors.Clear();
            }
            possibleColor = possibleColors[random.Next(0, possibleColors.Count)];
            while (selectedColors.Contains(possibleColor))
            {
                possibleColor = possibleColors[random.Next(0, possibleColors.Count)];
            }
            selectedColors.Add(possibleColor);
            return possibleColor;
        }

         private Color GetRandomColorOfLoist()
          {
            int index = random.Next(0, possibleColors.Count);
            Color ColorToReturn = possibleColors[index];
            possibleColors.Remove(possibleColors[index]);
            
            return ColorToReturn;
          }

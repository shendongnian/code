    private string Justify(string text, Font font, int width)
    {
        char SpaceChar = (char)0x200A;
        List<string> WordsList = text.Split((char)32).ToList();
        if (WordsList.Capacity < 2)
            return text;
        int NumberOfWords = WordsList.Capacity - 1;
        int WordsWidth = TextRenderer.MeasureText(text.Replace(" ", ""), font).Width;
        int SpaceCharWidth = TextRenderer.MeasureText(WordsList[0] + SpaceChar, font).Width
                           - TextRenderer.MeasureText(WordsList[0], font).Width;
        //Calculate the average spacing between each word minus the last one 
        int AverageSpace = ((width - WordsWidth) / NumberOfWords) / SpaceCharWidth;
        float AdjustSpace = (width - (WordsWidth + (AverageSpace * NumberOfWords * SpaceCharWidth)));
        //Add spaces to all words
        return ((Func<string>)(() => {
            string Spaces = "";
            string AdjustedWords = "";
            for (int h = 0; h < AverageSpace; h++)
                Spaces += SpaceChar;
            foreach (string Word in WordsList) {
                AdjustedWords += Word + Spaces;
                //Adjust the spacing if there's a reminder
                if (AdjustSpace > 0) {
                    AdjustedWords += SpaceChar;
                    AdjustSpace -= SpaceCharWidth;
                }
            }
            return AdjustedWords.TrimEnd();
        }))();
    }

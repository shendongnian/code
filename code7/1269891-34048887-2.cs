    public class HighlightableString : List<HighlightableChar>
    {
        private readonly string sourceString;
    
        public HighlightableString(string value)
        {
            sourceString = value;
            foreach (char currentChar in sourceString)
            {
                Add(new HighlightableChar(currentChar));
            }
        }
    
        public void Highlight(string searchString)
        {
            int index = sourceString.IndexOf(searchString);
            if (index > -1)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (i < index)
                    {
                        this[i].IsHighlighted = false;
                    }
                    else if (i >= index && i < index + searchString.Length)
                    {
                        this[i].IsHighlighted = true;
                    }
                    else
                    {
                        index = sourceString.IndexOf(searchString, index + 1);
                        this[i].IsHighlighted = false;
                    }
                }
            }
            else
            {
                foreach (HighlightableChar c in this)
                {
                    c.IsHighlighted = false;
                }
            }
        }
    }

        public class FormattedStringPart
        {
            public int ObjectIndex { get; private set; }
            public int StartIndex { get; private set; }
            public int Length { get; private set; }
            public FormattedStringPart(int objectIndex, int startIndex, int length)
            {
                ObjectIndex = objectIndex;
                StartIndex = startIndex;
                Length = length;
            }
        }

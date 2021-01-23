    public class HorizontalTextExtractionStrategy : LocationTextExtractionStrategy
    {
        public class HorizontalTextChunk : TextChunk
        {
            public HorizontalTextChunk(String stringValue, Vector startLocation, Vector endLocation, float charSpaceWidth, TextLineFinder textLineFinder)
                : base(stringValue, startLocation, endLocation, charSpaceWidth)
            {
                this.textLineFinder = textLineFinder;
            }
            override public int CompareTo(TextChunk rhs)
            {
                if (rhs is HorizontalTextChunk)
                {
                    HorizontalTextChunk horRhs = (HorizontalTextChunk) rhs;
                    int rslt = CompareInts(getLineNumber(), horRhs.getLineNumber());
                    if (rslt != 0) return rslt;
                    return CompareFloats(StartLocation[Vector.I1], rhs.StartLocation[Vector.I1]);
                }
                else
                    return base.CompareTo(rhs);
            }
            public override bool SameLine(TextChunk a)
            {
                if (a is HorizontalTextChunk)
                {
                    HorizontalTextChunk horAs = (HorizontalTextChunk) a;
                    return getLineNumber() == horAs.getLineNumber();
                }
                else
                    return base.SameLine(a);
            }
            public int getLineNumber()
            {
                Vector startLocation = StartLocation;
                float y = startLocation[Vector.I2];
                List<float> flips = textLineFinder.verticalFlips;
                if (flips == null || flips.Count == 0)
                    return 0;
                if (y < flips[0])
                    return flips.Count / 2 + 1;
                for (int i = 1; i < flips.Count; i+=2)
                {
                    if (y < flips[i])
                    {
                        return (1 + flips.Count - i) / 2;
                    }
                }
                return 0;
            }
            private static int CompareInts(int int1, int int2){
                return int1 == int2 ? 0 : int1 < int2 ? -1 : 1;
            }
            private static int CompareFloats(float float1, float float2)
            {
                return float1 == float2 ? 0 : float1 < float2 ? -1 : 1;
            }
            TextLineFinder textLineFinder;
        }
        public override void RenderText(TextRenderInfo renderInfo)
        {
            textLineFinder.RenderText(renderInfo);
            LineSegment segment = renderInfo.GetBaseline();
            if (renderInfo.GetRise() != 0){ // remove the rise from the baseline - we do this because the text from a super/subscript render operations should probably be considered as part of the baseline of the text the super/sub is relative to 
                Matrix riseOffsetTransform = new Matrix(0, -renderInfo.GetRise());
                segment = segment.TransformBy(riseOffsetTransform);
            }
            TextChunk location = new HorizontalTextChunk(renderInfo.GetText(), segment.GetStartPoint(), segment.GetEndPoint(), renderInfo.GetSingleSpaceWidth(), textLineFinder);
            getLocationalResult().Add(location);        
        }
        public HorizontalTextExtractionStrategy()
        {
            locationalResultField = typeof(LocationTextExtractionStrategy).GetField("locationalResult", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            textLineFinder = new TextLineFinder();
        }
        List<TextChunk> getLocationalResult()
        {
            return (List<TextChunk>) locationalResultField.GetValue(this);
        }
        System.Reflection.FieldInfo locationalResultField;
        TextLineFinder textLineFinder;
    }

    public class TextLineFinder : IRenderListener
    {
        public void BeginTextBlock() { }
        public void EndTextBlock() { }
        public void RenderImage(ImageRenderInfo renderInfo) { }
        public void RenderText(TextRenderInfo renderInfo)
        {
            LineSegment ascentLine = renderInfo.GetAscentLine();
            LineSegment descentLine = renderInfo.GetDescentLine();
            float[] yCoords = new float[]{
                ascentLine.GetStartPoint()[Vector.I2],
                ascentLine.GetEndPoint()[Vector.I2],
                descentLine.GetStartPoint()[Vector.I2],
                descentLine.GetEndPoint()[Vector.I2]
            };
            Array.Sort(yCoords);
            addVerticalUseSection(yCoords[0], yCoords[3]);
        }
        void addVerticalUseSection(float from, float to)
        {
            if (to < from)
            {
                float temp = to;
                to = from;
                from = temp;
            }
            int i=0, j=0;
            for (; i<verticalFlips.Count; i++)
            {
                float flip = verticalFlips[i];
                if (flip < from)
                    continue;
                for (j=i; j<verticalFlips.Count; j++)
                {
                    flip = verticalFlips[j];
                    if (flip < to)
                        continue;
                    break;
                }
                break;
            }
            bool fromOutsideInterval = i%2==0;
            bool toOutsideInterval = j%2==0;
            while (j-- > i)
                verticalFlips.RemoveAt(j);
            if (toOutsideInterval)
                verticalFlips.Insert(i, to);
            if (fromOutsideInterval)
                verticalFlips.Insert(i, from);
        }
        public List<float> verticalFlips = new List<float>();
    }

       public class Rectangle
        {
            public int x;
            public int y;
            public int width;
            public int height;
        }
    
        /// <summary>
        /// Creates array of objects
        /// </summary>
        protected T[] InitializeArray<T>(int length) where T : new()
        {
            T[] array = new T[length];
            for (int i = 0; i < length; ++i)
            {
                array[i] = new T();
            }
    
            return array;
        }
    
        /// <summary>
        /// Creates array of objects
        /// </summary>
        protected T[,] InitializeArray<T>(int length, int width) where T : new()
        {
            T[,] array = new T[length, width];
            for (int i = 0; i < length; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    array[i, j] = new T();
                }
            }
    
            return array;
        }
    
        protected class RectangleInBucket
        {
            public readonly Rectangle Rect;
            public readonly int RecNo;
            public readonly int bucketXFrom;
            public readonly int bucketXTo;
            public readonly int bucketYFrom;
            public readonly int bucketYTo;
            public RectangleInBucket(Rectangle rectangle, int recNo, int bucketSizeX, int bucketSizeY)
            {
                Rect = rectangle;
                RecNo = recNo;// arbitrary number unique for this rectangle
                bucketXFrom = Rect.x / bucketSizeX;
                bucketXTo = (Rect.x + Rect.width) / bucketSizeX;
                bucketYFrom = Rect.y / bucketSizeY;
                bucketYTo = (Rect.y + Rect.height) / bucketSizeY;
            }
        }
    
        /// <summary>
        /// Evaluates rectagle wrapped in RectangleInBucket object against all rectangles in bucket.
        /// Saves result into tmpResult.
        /// </summary>
        protected void processBucket(Dictionary<long, int> tmpResult, List<RectangleInBucket> bucket, RectangleInBucket rib)
        {
            foreach (RectangleInBucket bucketRect in bucket)
            {
                if (bucketRect.RecNo < rib.RecNo)
                {
                    long actualCouple = bucketRect.RecNo + (((long)rib.RecNo) << 32);
                    if (tmpResult.ContainsKey(actualCouple)) { continue; }
                    tmpResult[actualCouple] = overlap(bucketRect.Rect, rib.Rect) ? compare(bucketRect.Rect, rib.Rect) : 0;
                }
                else
                {
                    long actualCouple = rib.RecNo + (((long)bucketRect.RecNo) << 32);
                    if (tmpResult.ContainsKey(actualCouple)) { continue; }
                    tmpResult[actualCouple] = overlap(rib.Rect, bucketRect.Rect) ? compare(rib.Rect, bucketRect.Rect) : 0;
                }
            }
        }
    
        /// <summary>
        /// Calculates all couples of rectangles where result of "compare" function is not zero
        /// </summary>
        /// <param name="ra">Array of all rectangles</param>
        /// <param name="screenWidth"></param>
        /// <param name="screenHeight"></param>
        /// <returns>Couple of rectangles and value of "compare" function</returns>
        public List<Tuple<Rectangle, Rectangle, int>> GetRelations(Rectangle[] ra, int screenWidth, int screenHeight)
        {
            Dictionary<long, int> tmpResult = new Dictionary<long, int>();
            // the key represents couple of rectangles. As index of one rectangle is int,
            // two indexes can be stored in long. First index must be smaller than second,
            // this ensures couple can be inserted only once. Value of dictionary is result 
            // of "compare" function for this couple.
    
            int bucketSizeX = Math.Max(1, (int)Math.Sqrt(screenWidth * screenHeight / ra.Length));
            int bucketSizeY = bucketSizeX;
    
            int bucketsNoX = (screenWidth + bucketSizeX - 1) / bucketSizeX;
            int bucketsNoY = (screenHeight + bucketSizeY - 1) / bucketSizeY;
    
            List<RectangleInBucket>[,] buckets = InitializeArray<List<RectangleInBucket>>(bucketsNoX, bucketsNoY);
            List<RectangleInBucket>[] sortedRects = InitializeArray<List<RectangleInBucket>>(bucketsNoX);
    
            for (int i = 0; i < ra.Length; ++i)
            {
                RectangleInBucket rib = new RectangleInBucket(ra[i], i, bucketSizeX, bucketSizeY);
                sortedRects[rib.bucketXTo - rib.bucketXFrom].Add(rib);// basically radix sort
            }
    
            foreach (List<RectangleInBucket> sorted in sortedRects) // start with most narrow rectangles
            {
                foreach (RectangleInBucket rib in sorted) // all of one width (measured in buckets)
                {
                    for (int x = rib.bucketXFrom; x <= rib.bucketXTo; ++x)
                    {
                        for (int y = rib.bucketYFrom; y <= rib.bucketYTo; ++y)
                        {
                            processBucket(tmpResult, buckets[x, y], rib);
                        }
                    }
    
                    for (int y = rib.bucketYFrom; y <= rib.bucketYTo; ++y)
                    {
                        buckets[rib.bucketXFrom, y].Add(rib); // left edge of rectangle
                        if (rib.bucketXFrom != rib.bucketXTo)
                        {
                            buckets[rib.bucketXTo, y].Add(rib); // right edge of rectangle
                        }
                    }
                }
            }
    
            List<Tuple<Rectangle, Rectangle, int>> result = new List<Tuple<Rectangle, Rectangle, int>>(tmpResult.Count);
            foreach (var t in tmpResult) // transform dictionary into final list
            {
                if (t.Value != 0)
                {
                    result.Add(Tuple.Create(ra[(int)t.Key], ra[(int)(t.Key >> 32)], t.Value));
                }
            }
    
            return result;
        }

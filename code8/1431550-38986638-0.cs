    public class History
    {
        protected int eventCount = 0;
        protected int[] array;
        protected readonly int _intervalLength_ms;
        long actualTime = 0;
        int actIndex = 0;
        public History(int intervalLength_ms, int numberOfIntervals)
        {
            _intervalLength_ms = intervalLength_ms;
            array = new int[numberOfIntervals];
        }
        public int EventCount
        {
            get
            {
                Update();
                return eventCount;
            }
        }
        public void InsertEvent()
        {
            Update();
            array[actIndex]++;
            eventCount++;
        }
        protected void Update()
        {
            long newTime = DateTime.Now.Ticks / 10000 / _intervalLength_ms;
            while (newTime > actualTime && eventCount > 0)
            {
                actualTime++;
                actIndex++;
                if (actIndex >= array.Length)
                {
                    actIndex = 0;
                }
                eventCount -= array[actIndex];
                array[actIndex] = 0;
            }
            if (newTime > actualTime)
            {
                actualTime = newTime;
                actIndex = (int)(actualTime % array.Length);
            }
        }
    }

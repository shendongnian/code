        public int[] type
        {
            get
            {
                 return Enumerable.Range(0, NumberOfItems).Select(x => gettypeforitem(x)).ToArray();
            }
        }

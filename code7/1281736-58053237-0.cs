    private YouurDBContext context;
        public YouurDBContext Context
        {
            get
            {
                if (context==null)
                {
                    context = new YouurDBContext();
                }
                return context;
            }
            set { context = value; }
        }

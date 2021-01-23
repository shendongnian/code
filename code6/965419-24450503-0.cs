    public class Plan
    {
        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 1:
                        return this.a;
                    ...
                }
            }
            set
            {
                switch (index)
                {
                    case 1:
                        this.a = value;
                    ...
                }
            }
        }
    }

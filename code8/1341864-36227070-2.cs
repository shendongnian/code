        public class Guest : IComparable<Guest>
        {
            public bool f { get; set; }
            public bool g { get; set; }
            public bool s { get; set; }
            public string name { get; set; }
            public int CompareTo(Guest other)
            {
                int results = 0;
                if (this.f)
                {
                    if (other.f)
                    {
                        results = this.name.CompareTo(other.name);
                    }
                    else
                    {
                        results = 1;
                    }
                }
                else
                {
                    if (other.f)
                    {
                        results = -1;
                    }
                    else
                    {
                        if (this.g)
                        {
                            if (other.g)
                            {
                                results = this.name.CompareTo(other.name);
                            }
                            else
                            {
                                results = 1;
                            }
                        }
                        else
                        {
                            if (other.g)
                            {
                                results = -1;
                            }
                            else
                            {
                                if (this.s)
                                {
                                    if (other.s)
                                    {
                                        results = this.name.CompareTo(other.name);
                                    }
                                    else
                                    {
                                        results = 1;
                                    }
                                }
                                else
                                {
                                    results = this.name.CompareTo(other.name);
                                }
                            }
                        }
                    }
                }
                return results;
            }

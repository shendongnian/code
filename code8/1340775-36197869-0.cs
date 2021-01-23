        public class Send : IComparable<Send>
        {
            public string messageName { get; set; }
            public string Port { get; set; }
            public string Type { get; set; }
            public int CompareTo(Send other)
            {
                int results = 0;
                if (this.messageName != other.messageName)
                {
                    results = this.messageName.CompareTo(other.messageName);
                }
                else
                {
                    if (this.Port != other.Port)
                    {
                        results = this.Port.CompareTo(other.Port);
                    }
                    else
                    {
                        results = this.Type.CompareTo(other.Type);
                    }
                }
                return results;
            }
        }

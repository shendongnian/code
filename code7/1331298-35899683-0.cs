        private int SwitchEnum<T>(Enum G)
        {                        
            int next = Convert.ToInt32(G) + 1;
            if (Enum.IsDefined(typeof(T), next))
            {
                return next;
            }
            else
            {
                return 0;
            }
        }

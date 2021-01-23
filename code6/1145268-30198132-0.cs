    [Serializable]
    public class Kort
    {
        // Private enum that is invisible to the outside world.
        enum kortvalör 
        {
            Zero,
            One,
            Two,
            Three
        }
        kortvalör valör = kortvalör.Three;
        public int Value
        {
            get
            {
                return (int)valör;
            }
            set
            {
                // Check to make sure the incoming value is in a valid range.
                var newvalör = (kortvalör)value;
                if (Enum.IsDefined(typeof(kortvalör), newvalör))
                    valör = newvalör;
                else
                    valör = default(kortvalör);
            }
        }
    }

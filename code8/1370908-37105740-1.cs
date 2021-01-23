    public static int now {
            get {
                return (int)(DateTime.UtcNow.Subtract (new DateTime (1970, 1, 1))).TotalSeconds;
            }
        }

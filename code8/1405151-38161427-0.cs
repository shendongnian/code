    class Minivan : Car
        {
            //Inside a method
            public void Test()
            {
                maxSpeed = 100;
            }
            //Inside a constructor 
            public Minivan(int _maxSpeed)
            {
                maxSpeed = _maxSpeed;
            }
            //Inside a property
            public int MaxSpeed
            {
                get { return maxSpeed; }
                set { maxSpeed = value; }
            }
        }

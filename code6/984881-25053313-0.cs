    public struct AccelerationValue {
        public float min;
        public float max;
        public int speed;
        public AccelerationValue(float mn, float mx, int s) {
            min = mn;
            max = mx;
            speed = s;
        }
    }
	void Start () {
        AccelerationValue[] accelerationValues = {
                                                     new AccelerationValue(-0.2f, 0.2f, 17),
                                                     new AccelerationValue(-0.5f, -0.2f, 25)
                                                 };
        foreach (AccelerationValue v in accelerationValues)
        {
            if (Input.acceleration.y > v.min && Input.acceleration.y < v.max)
            {
                maxSpeed = v.speed;
            }
        }
	}

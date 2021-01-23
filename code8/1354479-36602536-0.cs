    class Car {
        private readonly object lockObject = new object();
        private int speed;
        private int gear;
        public int Speed {
            lock (lockObject) {
                return speed;
            }
        }
        public int Gear {
            lock (lockObject) {
                return gear;
            }
        }
        public int Gear{ get; }
        public Car(int speed, int gear) {
            // You can validate two attributes together
            if (speed != 0 && gear == 0) {
                throw new ArgumentException("Non-zero speed in zero gear");
            }
            this.speed = speed;
            this.gear= gear;
        }
        public void SpeedUp(int increase) {
            lock(lockObject) {
                var newSpeed = Math.Max(Speed + increase, 0);
                if (newSpeed > 200) {
                     throw new InvalidOperationexception("Cannot speed up past 200");
                }
                // Concurrent users would not see inconsistent speed setting
                Speed = newSpeed;
                Gear = Speed / 25;
            }
        }
    }

        private float Angle(float y, float x)
        {
            //Angle to go to
            RotationReference = -(float)(CorrectedAtan2(y, x));
            for (int i = 0; i < 60; i++)
            {
                if (Math.Abs(RotationReference - Rotation) > Math.PI)
                    RotationReference = -(float)(CorrectedAtan2(y, x) +
                        (Math.PI * 2 * i));
            }
            //Adds on top of rotation to steadily bring it closer
            //to the direction the analog stick is facing
            return Rotation += (RotationReference - Rotation) * Seconds * 15;
        }
        public static double CorrectedAtan2(double y, double x)
        {
            var angle = Math.Atan2(y, x);
            return angle < 0 ? angle + 2 * Math.PI: angle;
        }

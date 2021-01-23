        I know this isn't a perfect solution but it works.
        Thanks InBetween for the CorrectedAtan2 method.
        private void Angle()
        {
            //Angle to go to
            RotationReference = -(float)(CorrectedAtan2(YR, XR));
            /*if (Math.Abs(RotationReference - Rotation) > Math.PI)
                RotationReference = -(float)(CorrectedAtan2(YR, XR) + 
                    (Math.PI*2));*/
            for (int i = 0; i < 100000; i++)
            {
                if (Math.Abs(RotationReference - Rotation) > Math.PI)
                    RotationReference = -(float)(CorrectedAtan2(YR, XR) +
                        (Math.PI * 2 * i));
            }
            //Adds on top of rotation to steadily bring it closer
            //to the direction the analog stick is facing
            Rotation += (RotationReference - Rotation) * Seconds * 15;
        }
        public static double CorrectedAtan2(double y, double x)
        {
            var angle = Math.Atan2(y, x);
            return angle < 0 ? angle + 2 * Math.PI: angle;
        }

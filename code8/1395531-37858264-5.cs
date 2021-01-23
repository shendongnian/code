    public static class Foo {
        public static double ToRadians (this double angleIn10thofaDegree) {
            // Angle in 10th of a degree
            return (angleIn10thofaDegree * Math.PI) / 1800; 
        }
    }

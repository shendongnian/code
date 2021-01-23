    public static class Common
    {
       public static double[][] X(Func<double[][], ...> func, ...) => func(...);
    }
    public static class A
    {
        public static double[][] X(...) => ...
        public static double[][] Y(...) => Common.X(X, ...); // use A.X
        public static double[][] Z(...) => Common.X(X, ...); // use A.X
    }
    public static class B
    {
        public static double[][] X(...) => ...
        public static double[][] Y(...) => Common.X(X, ...); // use B.X
        public static double[][] Z(...) => Common.X(X, ...); // use B.X
    }

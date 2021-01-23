    class B : A
    {
        public static void MB()
        {
            var n = Number;   // var n = A.Number;
            MA();             // A.MA();
        }
    }

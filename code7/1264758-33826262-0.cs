        private void FooMethod()
        {
            int[] fooArray = {1,2,3,4,5 };
            AA(fooArray);
            foreach(var c in fooArray)
                Console.WriteLine(c);
        }
        private void AA(int[] bb)
        {
            bb[1] = 15;
        }

    class Program
    {
        // Problem statement
        //Create an array tower(a) containing all element in ascending order
        public static int[] towerSource = new int[] { 1, 3, 5,6,7,9,11,12,13,14,15,16,17};
        //solution statement
        //we have two more towers with same capacity, tower(b) as auxiliary and tower(c) as destination
        public static int[] towerAuxiliary;
        public static int[] towerDestination;
        public static void CreateTowers()
        {
            towerAuxiliary = new int[towerSource.Length];
            towerDestination = new int[towerSource.Length];
        }
        public static void Print(int[] tower)
        {
            for (int i = 0; i < tower.Length; i++)
                Write(tower[i].ToString());
            WriteLine("--------next run-------------");
        }       
        //start operation
        public static void TOH(int numberOfDisks, int[] source,int[] auxiliary,int[] destination)
        {
            //check if there is only one disk in source
            if(numberOfDisks == 1)
            {
                //move to destination and come out
                towerDestination[numberOfDisks-1] = towerSource[numberOfDisks-1];
                Print(towerDestination);
                return;
            }
            //move n-1 disks from source to auxiliary
            TOH(numberOfDisks - 1, towerSource, towerAuxiliary, towerDestination);
            towerDestination[numberOfDisks-1] = towerSource[numberOfDisks-1];
            //move nth disc from source to dest
            //this is being handeled by if condition
            //move n-1 disks from auxiliary to dest
            TOH(numberOfDisks - 1, towerAuxiliary, towerSource, towerDestination);
            return;
        }
        static void Main(string[] args)
        {
            CreateTowers();
            TOH(towerSource.Length, towerSource, towerAuxiliary, towerDestination);
        }
    }
}

    static Stack<Disk>[] towers;
    class Disk
    {
        public int Size {get; set;}
    }
    static void Main(string[] args)
    {
        // create the Stack<Disk> array
        towers = new Stack<Disk>[3];
        // create each tower
        for(int i=0;i<towers.Length;i++)
        {   
            towers[i] = new Stack<Disk>();
            // fill the towers.
            for(int j=3;j>0;j--)
                towers[i].Enqueue(new Disk {  Size = j });
        }
        
        bool isHoldingDisk = false;
        while(true)
        {
            DisplayTowers();
            if(isHoldingDisk)
                Console.WriteLine("On what tower do you want to place it?");
            else
                Console.WriteLine("Choose a tower to pick a disk");
            var key = Console.ReadKey(true);
            var chosenTowerIndex = 0;
            switch(key)
            {
                case(Key.Escape):
                    break;
                case(Key.D1):
                    chosenTowerIndex = 0;
                    break;
                case(Key.D1):
                    chosenTowerIndex = 1;
                    break;
                case(Key.D1):
                    chosenTowerIndex = 2;
                    break;
                // etc...
            }
            if((chosenTowerIndex < 1) || (chosenTowerIndex >= towers.Length))
                continue;
            // check here if you are holding a disk
            if(isHoldingDisk)
            {
                // logic for testing if you can place the disk here... 
                // using towers[chosenTowerIndex]
                // check if it is completed...
                if(completed)
                    break;
                isHoldingDisk = false;
            }
            else
            {
                // check if you can pickup a disk....(if there is any)
                isHoldingDisk = true;
            }
        }
        // final display...
        DisplayTowers();
        Console.WriteLine("Thanks for playing");
    }
    static void DisplayTowers()
    {
        
    }

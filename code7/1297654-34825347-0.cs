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
            for(int j=3;j>0;j++)
                towers[i].Enqueue(new Disk {  Size = j });
        }
        
        
    }

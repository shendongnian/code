    private int ID; // do NOT lock on value type instances
    private static readonly object Lock = new object ();
    public Person(int id)
    {
        this.Identification = id;
    }
    
    public int Identification
    {
        get
        { 
            lock ( Lock )
            {
                return this.ID;
            }
        }
    
        private set
        {
            if (value == 0)
                throw new ArgumentNullException("Must Include ID#");
            
            lock ( Lock )
            {
                this.ID = value;
            }
        }
    }

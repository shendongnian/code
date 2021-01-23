    public class PlayerData 
    {
        public bool isAlive
        {
            get;
            set;
        }
    
        public string Name
        {
            get;
            set;
        }
    
        public PlayerData()
        {
            isAlive = false; // redundant isAlive == false by default
            Name = "";
        }
    
        // redundant: you can easily put isAlive = value;
        public void SetisAlive(bool value)
        {
            isAlive = value;
        }
    }

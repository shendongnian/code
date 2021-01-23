    public class Block
    {
        public int id;
        public string name;
        public int profileIconId;
        public int revisionDate;
        public int summonerLevel;
    }
    
    public class BlockWrapper
    {
        public Block block4o;
    }
    //...
    BlockWrapper blockWrapper = JsonConvert.DeserializeObject<BlockWrapper>(text);

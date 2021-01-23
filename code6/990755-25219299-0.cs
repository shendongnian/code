    public class CollectionFactory
    {
    	private readonly BinaryReader _reader;
    	public CollectionFactory(BinaryReader reader)
    	{
            if (reader == null)
            {
                throw ArgumentNullException(reader);
            }
    		_reader = reader;
    	}
    	
    	public CollectionType CreateInstance()
    	{
    		using (_reader)
    		{
    			// General collectible stuff, position, synced anim...
    			var x = _reader.ReadInt32();
    			var y = _reader.ReadInt32();
    			var musicStartCode = reader.ReadInt32();
    			var musicBpm = reader.ReadInt32();
    			// ...
    		
    			// Tricky part: sub-type specific information follows
    			CollectibleType collectableType = (CollectibleType)reader.ReadByte();
    			
    			if (collectableType is Coin)
    			{
    				return new Coin 
    				{
    					X = x, 		
    					Y = y,
    					MusicStartCode = musicStartCode
                        // etc..
    				};
    			}
    			if (collectableType is ItemBox)
    			{
    				return new ItemBox
    				{
    					X = x, 		
    					Y = y,
    					MusicStartCode = musicStartCode
                        // etc..
    				};
    			}
    		}
    	}
    }

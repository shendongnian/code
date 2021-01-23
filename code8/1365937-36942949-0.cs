    using System; /* contains: Serializable */
    using System.Collections; /* contains: ArrayList */
    using System.Collections.Generic; /* contains: definition of List<> */
    using System.Data.SqlTypes; /* contains: definition of SqlDouble (FLOAT in T-SQL) */
    using System.IO; /* contains: BinaryReader and BinaryWriter */
    using System.IO.Compression; /* contains: DeflateStream and InflateStream */
    using Microsoft.SqlServer.Server; /* contains: SqlUserDefinedAggregate */
    [Serializable]
    [SqlUserDefinedAggregate(
	Format.UserDefined,	
	IsInvariantToNulls = true, 
	IsInvariantToDuplicates = false, 
	IsInvariantToOrder = true, 
	IsNullIfEmpty = true, 
	MaxByteSize = 8000, 
	Name = "Median" 
	)
    ]
    public class Agg_Median : IBinarySerialize 
    {
    	private List<Double> ValueList; 
    	public void Init()
    	{
    		this.ValueList = new List<Double>(); 
    	}
    
    	public void Accumulate(SqlDouble value) 
    	{
    		if (value.IsNull)
    		{
    			return; 
    		}
    
    		this.ValueList.Add(value.Value); 
    	}
    
    	public void Merge(Agg_Median other) /* combine data from parallel     operations */
    	{
    		this.ValueList.AddRange(other.ValueList);
    	}
    
    	public SqlDouble Terminate() /* this method is called at the end to     return the result */
    	{
    		double __Median = 0.0D; /* local variable to hold and calculate     final result */
    		int __Count = 0; /* local variable to hold number of values in list     */
    
    		this.ValueList.Sort(); /* arrange the list of values in order so we     can determine
    					* middle value(s)
    					*/
    
    		__Count = this.ValueList.Count; /* we need to know how many in order     to find the middle */
    
    		/* if there is at least one value we will calculate the Median, else     we return a NULL FLOAT
    		 */
    		if (__Count > 0)
    		{
    			if (__Count % 2 == 0) /* if even number of values, middle will     be two values */
    			{
    				__Median = (
    					((double)this.ValueList[(__Count / 2) - 1] +
    						(double)this.ValueList[(__Count / 2)]) / 2.0
    				); /* average the two middle values */
    			}
    			else /* there are an odd number of values so there is only one     middle value */
    			{
    				__Median =     (double)this.ValueList[Convert.ToInt32(Math.Floor(__Count / 2.0))];
    			}
    
    			/* send the final result back to SQL Server as a FLOAT (same as     SqlDouble in .Net) */
    			return new SqlDouble(__Median);
    		}
    		else
    		{
    			return SqlDouble.Null;
    		}
    	}
    
    	public void Read(BinaryReader Serialized)
    	{
    		BinaryReader __FromSerialize; /* variable to hold decompressed     serialized binary data */
    
    		using (MemoryStream  __MemoryStreamIn = 
    		new MemoryStream ((byte[])Serialized.ReadBytes(Convert.ToInt32(Serialized.BaseStream.Length))))
    		{
    			using (DeflateStream __DecompressStream = 
    					new DeflateStream(__MemoryStreamIn,     CompressionMode.Decompress))
    			{
    				using (MemoryStream  __MemoryStreamOut = new MemoryStream     ())
    				{
    					
					for (int __Byte = __DecompressStream.ReadByte(); __Byte !=     -1;
    								__Byte = __DecompressStream.ReadByte())
    					{
    						__MemoryStreamOut.WriteByte((byte)__Byte);
    					}
    
    					__FromSerialize = new BinaryReader(__MemoryStreamOut);
    
    		
    					__FromSerialize.BaseStream.Position = 0;
    
    					int __CountDoubles = __FromSerialize.ReadInt32();
    
    					if (__CountDoubles > -1)
    					{
    				
    						this.ValueList = new List<Double>(__CountDoubles);
    
    						for (int __Index = 0; __Index < __CountDoubles;     __Index++)
    						{
    							    this.ValueList.Add(__FromSerialize.ReadDouble());
    						}
    					}
    				}
    			}
    		}
    	}
    
    	public void Write(BinaryWriter ToBeSerialized)
    	{
    		MemoryStream __ToCompress = new MemoryStream(); 
    		BinaryWriter __BinaryWriter = new BinaryWriter(__ToCompress); 
    
    		__BinaryWriter.Write(this.ValueList.Count);
    
    		this.ValueList.Sort(); 
    
    			foreach (double __TempDouble in this.ValueList)
    		{
	    		__BinaryWriter.Write(__TempDouble);
       		}
    
    		using (MemoryStream __ToSerialize = new MemoryStream())
    		{
    			
    			using (DeflateStream __CompressStream =
    					new DeflateStream(__ToSerialize,     CompressionMode.Compress, true))
    			{				
    				byte[] __TempArray = (byte[])__ToCompress.ToArray();
    		
    				__CompressStream.Write(__TempArray, 0, __TempArray.Length);
    			}
    			ToBeSerialized.Write(__ToSerialize.ToArray());
    		}
    	}
    }
    

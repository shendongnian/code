    using System;
    using System.Linq;
    
    public class Test
    {
    	public static int FlippingBits(int[] bits){
    		int currentOne = 0; //original number of 1s in bits
    		foreach(int i in bits){
    			if(i==1)
    				currentOne++;
    		}
    		int minRes = MinSubArray(bits); //minRes is negative number
    		return currentOne-minRes;
    	}
    	
    	//find the min sum of subArray in bits
    	private static int MinSubArray(int[] bits){
    		int minRes = 0, minHere=0;
    		foreach(int i in bits){
    			if(i==0)
    				minHere-=1;
    			else
    				minHere+=1;
    			minHere = Math.Min(minHere,0); //keep minHere<=0
    			minRes = Math.Min(minHere, minRes);
    		}
    		return minRes; //-minRes is the number of 1 can be added to the array after flipping
    	}
    	
    	public static void Main()
    	{
    		int num = int.Parse(Console.ReadLine());
    		for(int i=0;i<num;i++){
    			string[] input = Console.ReadLine().Split();
    			int[] bits = input.Select(y=>int.Parse(y)).ToArray();
    			Console.WriteLine(FlippingBits(bits));
    		}
    	}
    }

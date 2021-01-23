    using UnityEngine;
    using System.Collections;
    
    public static class DelagetsAndEvents {
    
    	public delegate int UnitEventHandler(string _unit);
    	public static event UnitEventHandler unitSpawn;
    
    	public static int[] UnitSpawn(string _unit)
    	{
    		if(unitSpawn != null)
    		{
    			unitSpawn(_unit);
    		}
    
    	
    
    		System.Delegate[] funcs = unitSpawn.GetInvocationList();
    		int[] TIntArray = new int[funcs.Length];
    
    		for (int i = 0; i < funcs.Length; ++i)
    		{
    			TIntArray[i] = (int) funcs[i].DynamicInvoke(_unit);
    
    
    		}
    
    		return TIntArray;
    	}
    }
    
    public class Planet {
    
    	public Planet()
    	{
    		DelagetsAndEvents.unitSpawn += UnitSpawn;
    	}
    
    	int UnitSpawn(string _unit)
    	{
    		Debug.Log("yo");
    		return 1;
    	}
    }
    
    public class SolarSystem{
    	
    	public SolarSystem()
    	{
    		DelagetsAndEvents.unitSpawn += UnitSpawn;
    	}
    
    	int UnitSpawn(string _unit)
    	{
    		Debug.Log("bla");
    		return 2;
    	}
    }

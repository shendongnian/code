    using UnityEngine;
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;
    
    public class MotionPlugin 
    {
    	[DllImport("__Internal")]
        private static extern void GetGyroXYZ(float[] xyz);
    
    	public static Vector3 GetGyro()
    	{
    		float [] xyz = {0, 0, 0};
    			GetGyroXYZ(xyz);
    			return new Vector3(xyz[0], xyz[1], xyz[2]);
    	}
    }

    using UnityEngine;
    using System.Collections;
    using System;
    public class Timeload : MonoBehaviour {
	
	DateTime  currentDate;
	DateTime  oldDate;
	
	public double timex;
	
	void Start()
	{
		//Store the current time when it starts
		currentDate = System.DateTime.Now;
		
		//Grab the old time from the playerprefs as a long
		long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));
		
		//Convert the old time from binary to a DataTime variable
		DateTime oldDate = DateTime.FromBinary(temp);
		print("oldDate: " + oldDate);
		
		//Use the Subtract method and store the result as a timespan variable
		TimeSpan difference = currentDate.Subtract(oldDate);
		print("Difference: " + difference.TotalSeconds);
		timex = timex + difference.TotalSeconds;
	}
	
	void OnApplicationQuit()
	{
		//Save the current system time as a string in the playerprefs class
		PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());
		
		print("Saving this date to prefs: " + System.DateTime.Now);
	}	
    }

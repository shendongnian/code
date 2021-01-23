	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
	namespace Vuforia
	{
		public class ZoneDictonary : MonoBehaviour 
		{   
			public Vector3 Zone1V;
			public Vector3 Zone2V;
			public Vector3 Zone3V;
			public Vector3 Zone4V;
			public Vector3 Zone5V;
            // Dictionary must be here to access from outside of this script
			public Dictionary<Vector3, bool> isZoneEmpty = new Dictionary<Vector3, bool> ();
			void Start()
			{
				isZoneEmpty.Add (Zone1V, true);
				isZoneEmpty.Add (Zone2V, true);
				isZoneEmpty.Add (Zone3V, true);
				isZoneEmpty.Add (Zone4V, true);
				isZoneEmpty.Add (Zone5V, true);
			}
		}
	}
...
	
	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
	namespace Vuforia
	{
		public class Test : MonoBehaviour 
		{
			ZoneDictonary Zd;
			void Start()
			{
				GameObject ZD = GameObject.FindGameObjectWithTag ("Zone Manager");
				Zd = ZD.GetComponent<ZoneDictonary> ();
				
				foreach(Vector3 key in Zd.isZoneEmpty.Keys)
				{
					//do something with keys
				}
			}
		}
	}

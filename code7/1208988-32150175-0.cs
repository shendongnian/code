	using UnityEngine;
	using Newtonsoft.Json;
	public class JsonThings : MonoBehaviour
	{
		public class ParseObject
		{		
			[JsonProperty]
			public int gameId;
			[JsonProperty]
			public string player;
			public ParseObject(string name)
			{
			}
		}
		// Use this for initialization
		void Start () 
		{
			ParseObject test = new ParseObject("jsontest");
			test.gameId = 12345;
			test.player = "hanson";
			string parsetoJson = JsonConvert.SerializeObject(test);
			Debug.Log("ParseJson: " + parsetoJson);
			//Returns: ParseJson: [{"Key":"gameid","Value":"12345"},{"Key":"player","Value":"hanson"}]
			ParseObject test2 = new ParseObject("jsontest");
			test2 = JsonConvert.DeserializeObject<ParseObject>(parsetoJson);
			Debug.Log("ParseBack: " + test2.gameId);	
		}
	}

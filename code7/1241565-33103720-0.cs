	using System;
	using Newtonsoft.Json;
	using System.Collections.Generic;
						
	public class Program
	{
		public static void Main()
		{
			// Deserialize the JSON into a list of CardData
			var ob = JsonConvert.DeserializeObject<List<CardData>>("[{\"id\":\"CS_001\",\"name\":\"L'élément\",\"type\":\"Tôt\"},{\"id\":\"CS_002\",\"name\":\"L'outrage\",\"type\":\"Tôt\"},{\"id\":\"CS_003\",\"name\":\"Test\",\"type\":\"Tôt\"}]" );
			
			/*
			  The output will be:
				id: CS_001, name: L'élément, type: Tôt
				id: CS_002, name: L'outrage, type: Tôt
				id: CS_003, name: Test, type: Tôt
			*/
			foreach(var i in ob){
				Console.WriteLine(i);  
			}
		}
	}
	// Class that will hold the deserialized data
	// For demo puposes
	public class CardData
	{
		public string id { get; set; }
		public string name { get; set; }
		public string type { get; set; }
		
		public override string ToString(){
			return String.Format("id: {0}, name: {1}, type: {2}",id, name, type);	
		}
	}

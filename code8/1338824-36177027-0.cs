    void CreateExpendableListData ()
		{
			for (int i = 0; i < sorted.Count; i++) {
				var lstChild = new List<string> ();
				var test = new List<string> ();
				test.Add ("Address: " + sorted [i].chargingPointID.address);
				test.Add ("Type: " + sorted [i].chargingPointID.type);
				test.Add ("Price: €" + sorted [i].chargingPointID.price.ToString ());
				for (int j = 0; j < test.Count; j++) {
					lstChild.Add (test [j]);
					Console.WriteLine (test [j]);
				}
				Console.WriteLine ("TEST LOOP: ", sorted [i].chargingPointID.address);
				dictGroup.Add (string.Format (Convert.ToDateTime (sorted [i].startTime).ToShortDateString ()), lstChild);
			}
			lstKeys = new List<string> (dictGroup.Keys);
		}

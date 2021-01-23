	Task myFirstTask = Task.Factory.StartNew(()
		 => 
		 {
			 while (stopped == false)
			 {
				 List<double> data = new List<double>();
				 for (int i = 0; i < iAvail; i++)
				 {
					data.Add(dScaledData[i]);
				 }
				 
				 Write(data.ToArray(), filename);
			 }
		 });

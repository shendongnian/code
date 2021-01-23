    List<string> resEmp = new List<string>();
    foreach (var item in workers )
	 {
		 if (item.Id == 2 and item.IsOff == false)
          {
            resEmp.Add(item);
          }
	 }

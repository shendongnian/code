    // example input
	string input = "6524562164126412641206685";
	var result = input
		// interpret the string as a list of digits with position
		.Reverse()
		// transfer from list of positioned digits to list of actual bit positions,
		// by repeatedly multiplying with 10
        // the resulting bits need to be added for the final result
		.SelectMany((x, i) =>
		{
			// digit value
			var val1 = x - '0';
			var res1 = new List<int>();
			// to bit positions, as if it was the first digit
			for (int j = 0; j < 8; j++)
			{
				if ((val1 & (1 << j)) != 0) res1.Add(j);
			}
			// to absolute bit positions, taking the digit position into account
			for (int j = 1; j <= i; j++)
			{
				var res = new List<int>();
				// multiply by 10, until actual position is reached
				foreach (var item in res1)
				{
					res.Add(item + 1);
					res.Add(item + 3);
				}
				// compress bits
				res1 = res.Aggregate(new HashSet<int>(), (set, i1) =>
					{
						// two bits in the same position add up to one bit in a higher position
						while (set.Contains(i1))
						{
							set.Remove(i1);
							i1++;
						}
						set.Add(i1);
						return set;
					}).ToList();
			}
			return res1;
		}).
        // final elimination of duplicate bit indices
		Aggregate(new HashSet<int>(), (set, i) =>
		{
			while (set.Contains(i))
			{
				set.Remove(i);
				i++;
			}
			set.Add(i);
			return set;
		})
		// transfer bit positions into a byte array - lowest bit is the last bit of the first byte
		.Aggregate(new byte[input.Length / 2], (res, bitpos) =>
		{
			res[bitpos / 8] |= (byte)(1 << (bitpos % 8));
			return res;
		});
		

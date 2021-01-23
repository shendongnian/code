    public static void Main()
	{
		int n;
		bool isNumeric;
		string input = "1+2*3/4-5+6*7/8-9";
		string[] addSplit = input.Split('+');
		double addTotal = 0;
		foreach (string addCode in addSplit)
		{
			isNumeric = int.TryParse(addCode, out n);
			if (isNumeric)
			{
				addTotal += n;
			}
			else
			{
				string[] addMinus = addCode.Split('-');
				double minusTotal = 0;
				bool firstMinus = true;
				foreach (string minusCode in addMinus)
				{
					isNumeric = int.TryParse(minusCode, out n);
					if (isNumeric)
					{
						if (firstMinus) { 
							minusTotal = n;
							firstMinus = false;
						}
						else {
							minusTotal -= n;
						}
					}
					else
					{
						string[] multySplit = minusCode.Split('*');
						double multyTotal = 1;
						foreach (string multyCode in multySplit)
						{
							isNumeric = int.TryParse(multyCode, out n);
							if (isNumeric)
							{
								multyTotal *= n;
							}
							else
							{
								string[] divSplit = multyCode.Split('/');								
								int.TryParse(divSplit[0], out n);								
								double divTotal = n;	
								
								for( int i = 1; i < divSplit.Length ; i++ ) {	
									int.TryParse(divSplit[i], out n);
									divTotal /= n;
								}
								multyTotal *= divTotal;							
							}
						}
						if (firstMinus) { 
							minusTotal = multyTotal;
							firstMinus = false;
						}
						else {
							minusTotal -= multyTotal;
						}	
					}
				}
				addTotal += minusTotal;
			}
		}
		Console.WriteLine("addTotal: " + addTotal);
	}

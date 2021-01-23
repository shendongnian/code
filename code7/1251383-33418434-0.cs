	List<int> list1 = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
	List<int> list2 = new List<int>() { 2, 2, 2, 2, 2 };
	int list1Counter = 0;
	int list2Counter = 0;
	int arraychecker = 1;
	int[] resultArray = new int[list1.Count + list2.Count];
	for (int i = 0; i < resultArray.Length; i++)
	{
		if (list1Counter < list1.Count && list2Counter < list2.Count)
		{
			if (arraychecker == 1 || arraychecker == 2)
			{
				resultArray[i] = list1[list1Counter];
				list1Counter++;
				arraychecker++;
			}
			else
			{
				resultArray[i] = list2[list2Counter];
				list2Counter++;
				arraychecker = 1;
			}
		}
		else if (list1Counter < list1.Count)
		{
			resultArray[i] = list1[list1Counter];
			list1Counter++;
		}
		else
		{
			resultArray[i] = list2[list2Counter];
			list2Counter++;
		}
	}

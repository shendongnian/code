	List<int[]> list = new List<int[]>();
	int[] array1 = new int[]{ 1, 2, 3, 4, 5 };
	int[] array2 = new int[]{ 5, 4, 3, 2, 1 };
	list.Add(array1);
	// add other arrays to list
	bool found = true;
	foreach (int[] other in list)
	{
		if (array2.Length == other.Length)
		{
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i] != other[i])
				{
					found = false;
					break;
				}
			}
		}
		else
		{
			found = false;
		}
		if (!found)
		{
			break;
		}
	}

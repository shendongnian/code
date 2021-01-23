            int arrayLength = arr.Length;
			int tmpCell = 0;
			for (int rotation = 1; rotation <= d; rotation++)
			{
				for (int i = 0; i < arrayLength; i++)
				{
					if (arr[i] < arrayElementMinValue || arr[i] > arrayElementMaxValue)
					{
						throw new ArgumentException($"Array element needs to be between {arrayElementMinValue} and {arrayElementMaxValue}");
					}
					if (i == 0)
					{
						tmpCell = arr[0];
						arr[0] = arr[1];
					}
					else if (i == arrayLength - 1)
					{
						arr[arrayLength - 1] = tmpCell;
					}
					else
					{
						arr[i] = arr[i + 1];
					}
				}
			}

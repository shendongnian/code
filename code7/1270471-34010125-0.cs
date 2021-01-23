		public static Boolean checkWords(String smallerWord, String biggerWord)
		{
			int position = 0;
			bool gotFirst = false;
			bool gotAnother = false;
			int positionBigger = 0;
			String word = "";
			for(int positionSmaller = 0; positionSmaller < smallerWord.Length; positionSmaller++)
			{
				if(!gotFirst)
				{
					if(biggerWord.Contains(smallerWord[positionSmaller].ToString()))
					{
						position = biggerWord.IndexOf(smallerWord[positionSmaller].ToString());
						gotFirst = true;
						word = smallerWord[positionSmaller].ToString();
					}
				}
				else
				{
					gotAnother = false;
					positionBigger = position + 1;
					while(!gotAnother)
					{
						if(positionBigger < biggerWord.Length)
						{
							if(biggerWord[positionBigger].ToString().Equals(smallerWord[positionSmaller].ToString()))
							{
								position = positionBigger;
								gotAnother = true;
								word += smallerWord[positionSmaller].ToString();
							}
							else
							{
								positionBigger++;
							}
						}
						else
						{
							gotAnother = true;
						}
					}
				}
			}
			if(smallerWord.Equals(word))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

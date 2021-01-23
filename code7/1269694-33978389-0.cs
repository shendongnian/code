            string polynomial = "x^2 + 3x + 5";
			int index = 0,highestdegree = 0;
			foreach (char character in polynomial) {
				if(character == '^')
				{
					index++;
					try{
						int test;
						int.TryParse(polynomial[index],out test);
						if(test >highestdegree)
							highestdegree = test;
						index--;
					}
					catch{
						index--;
					}
				}
				index += 1;
			}
          if(highest degree == 0)
           { 
                highestdegree == 1;
           }
          return highest degree;

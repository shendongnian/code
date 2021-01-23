                List<int> digits = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                Random ran = new Random();
                string ranString = "";
                for(int i = 0; i < 4; i++)
                {
                    int index = ran.Next(0, digits.Count);
                    ranString += digits[index].ToString();
                    digits.RemoveAt(index);
                }

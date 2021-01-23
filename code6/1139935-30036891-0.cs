    public static string CapsFirstLetter(string inputValue)
        {
            char[] values = new char[inputValue.Length];
            int count = 0;
            foreach (char f in inputValue){
                if (count == 0){
                    values[count] = Convert.ToChar(f.ToString().ToUpper());
                }
                else{
                    values[count] = f;
                }
                count++;
            }
            return new string(values);
        }

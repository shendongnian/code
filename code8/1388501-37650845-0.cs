            string valuesNew = "To dO someThing in HomEWork";
            char[] array = valuesNew.ToCharArray();
            string result = array[0].ToString();
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    array[i] = char.ToUpper(array[i]);
                    result += array[i];
                }
            }
            return result;

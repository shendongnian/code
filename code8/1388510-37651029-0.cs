    public static string GetString()
            {
                string valuesNew = "Foo";
                char[] array = valuesNew.ToCharArray();
                string result = "";
                for (int i = 0; i < array.Length; i++)
                {
                    if (i == 0)
                    {
                        array[i] = char.ToUpper(array[i]);
                        result += array[i] + " ";
                    }
                }
                return result;
            }

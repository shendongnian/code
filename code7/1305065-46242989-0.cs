    public static string HappyOrSad(string input, char[] arr)
        {
            int result = 0;
            // Hashset to store ouput of each loop
            HashSet<int> repNumber = new HashSet<int>();
            // If number is repeated, break the loop
            while (!repNumber.Contains(result) )
            {
                int temp = 0;
                repNumber.Add(result);
                for (int i = 0; i < arr.Length; i++)
                {
                    // Converting character array to integer
                    temp += Convert.ToInt32(arr[i].ToString()) * Convert.ToInt32(arr[i].ToString());
                }                
                arr = temp.ToString().ToCharArray();
                result = temp;                
            }
            return result == 1 ? "Happy" : "Sad";
        }

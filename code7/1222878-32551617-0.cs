        public static bool IsPalindrome(string checkString)
        {
            if (string.IsNullOrEmpty(checkString))
                return false;
            char[] arr = checkString.ToCharArray();
            for (int i = 0; i < arr.Length/2; i++)
            {
                if (arr[i] != arr[arr.Length - i - 1])
                    return false;
            }
            return true;
        }

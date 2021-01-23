         public string GetString(string Path1, string Path2)
        {
           
            //Split and Put everything between / in the arrays
            string[] Arr_String1 = Path1.Split('/');
            string[] Arr_String2 = Path2.Split('/');
            string Result = "";
            for (int i = 0; i <= Arr_String1.Length; i++)
            {
                if (Arr_String1[i] == Arr_String2[i])
                {
                  //Puts the Content that is the same in an Result string with /
                    Result += Arr_String1[i] + '/';
                    }
                else
                    break;
            }
            // If Path is identical he would add a / which we dont want 
            if (Result.Contains('.'))
            {
                Result = Result.TrimEnd('/');
            }
            return Result;
        }

    public static object[][] bloop(string[] bstr)
        {
            object[][] result = new object[2][] { new object[bstr.Length], new object[bstr.Length] };
            int sFlag = 0, iFlag = 0, val;            
            foreach (string str in bstr)
                if (int.TryParse(str, out val))
                    result[1][iFlag++] = val;
                else
                    result[0][sFlag++] = str;
            return result;
        }

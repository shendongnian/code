        public string UrlEncode(string str)
        {
            if (str == null || str == "")
            {
                return null;
            }
            byte[] bytesToEncode = System.Text.UTF8Encoding.UTF8.GetBytes(str);
            String returnVal = System.Convert.ToBase64String(bytesToEncode);
            return returnVal.TrimEnd('=').Replace('+', '-').Replace('/', '_');
        }
        public string UrlDecode(string str)
        {
            if (str == null || str == "")
            {
                return null;
            }
            str.Replace('-', '+');
            str.Replace('_', '/');
            int paddings = str.Length % 4;
            if (paddings > 0)
            {
                str += new string('=', 4 - paddings);
            }
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(str);
            string returnVal = System.Text.UTF8Encoding.UTF8.GetString(encodedDataAsBytes);
            return returnVal;
        }

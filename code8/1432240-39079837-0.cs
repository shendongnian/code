    public bool isInWorkingDir(string url)
        {
            bool inDir = false;
            string lowerUrl = url.ToLower();
            if (lowerUrl.Contains("myRegion/mySite") && countSlash(url)>6)
            {
                inDir = true;
            }
            return inDir;
        }
        public int countSlash(string url)
        {
            int length = url.Length;
            int count = 0;
            for (int n = length - 1; n >= 0; n--)
            {
                if (url[n] == '/')
                    count++;
            }
            return count;
        }

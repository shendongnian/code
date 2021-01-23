    class CustomFile
    {
        public string FileName { get; private set; }
        public Version FileVersion { get; private set; }
        public CustomFile(string file)
        {
            var split = file.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int versionIndex;
            int temp;
            for (int i = split.Length - 2; i >= 0; i--)
            {
                if (!Int32.TryParse(split[i], out temp))
                {
                    versionIndex = i+1;
                    break;
                }
            }
            FileName = string.Join(".", split, 0, versionIndex);
            FileVersion = Version.Parse(string.Join(".", split, versionIndex, split.Length - versionIndex - 1));
        }
    }

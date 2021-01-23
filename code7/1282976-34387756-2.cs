    public static object Load(string saveTag) {
            string temp = PlayerPrefs.GetString(saveTag);
            if (temp == string.Empty) {
                return null;
            }
            MemoryStream memoryStream = new MemoryStream(System.Convert.FromBase64String(temp));
            return binaryFormatter.Deserialize(memoryStream);
        }

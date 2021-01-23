    public class Demo
    {
        public void ReadJSON()
        {
            string path = Application.streamingAssetsPath + "/Player.json";
            string JSONString = File.ReadAllText(path);
            Player player = JsonUtility.FromJson<Player>(JSONString);
            Debug.Log(player.Name);
        }
    }
            
    [System.Serializable]
    public class Player
    {
        public string Name;
        public int Level;
    }

    static void SaveEnemies(Enemies [] enemies, string path){
        Root root = new Root(enemies);
        string json = JsonUtility.ToJson(root);
        File. WriteAllText(path, root);
    }

        public bool loadGameData() {
            if(gameData == null) {
                gameData = new List<GameData>();
            } else {
                gameData.Clear();
            }
            bool loadData = true;
            bool OK = false;
            if(File.Exists(gameDataFile[currentDifficulty])) {
                FileStream file = File.Open(gameDataFile[currentDifficulty], FileMode.Open);
                BinaryReader br = new BinaryReader(file);
                while(loadData) {
                    try {
                        GameData gd = new GameData();
                        gd.id = br.ReadInt32();
                        gd.difficulty = br.ReadInt32();
                        gd.content = getByteData(br.ReadBytes(puzzleSize));
                        gameData.Add(gd);
                        OK = true;
                        if(file.Position == file.Length) {
                            loadData = false;
                        }
                    } catch(Exception e) {
                        Debug.LogException(e);
                        loadData = false;
                        OK = false;
                    }
                }
                if(file != null) {
                    file.Close();
                }
            } else {
                Debug.LogWarning(gameDataFile[currentDifficulty] + " does not exist!");
            }
            return OK;
        }

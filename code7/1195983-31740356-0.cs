    public enum Game : int {
        Terminal = 0,
        // ...
    }
 
    // add the explicit cast to int here
    GameType.Add(
        new GameTypeModel() { 
            Value = value, 
            TransKey = ((int)val).ToString() 
        });

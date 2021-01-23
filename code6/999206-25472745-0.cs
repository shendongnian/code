        public async Task Example()
        {
           ParseObject gameScore = new ParseObject("Test");
           gameScore["score"] = 1337;
           gameScore["playerName"] = "Test User";
           await gameScore.SaveAsync();
        }

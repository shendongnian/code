    if (gameType == GameType.Single)
        return new Game(
            GameType.Single,
            new List<IPlayer> { CreateHuman(); CreateBot() });
    else if (gameType == GameType.PassAndPlay)
        return new Game(
            GameType.PassAndPlay,
            new List<IPlayer> { CreateHuman(); CreateHuman() });
    else
        return new Game(
            GameType.Online,
            new List<IPlayer> { CreateHuman(); CreateOnlinePlayer() });

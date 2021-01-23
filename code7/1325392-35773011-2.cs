    SaveLoadGameDataController FakeSaveLoadGameDataController ()
	{
		SaveLoadGameDataController slgdController = Substitute.For<SaveLoadGameDataController>();
		ISaveLoadGameData slgd = Substitute.For<ISaveLoadGameData>();
		slgdController.SetSaveLoadGameData(slgd);
			
		slgdController.experience = Arg.Is<float>(x => x > 0);
		slgdController.score = Arg.Is<float>(x => x > 0);
			
		return slgdController;
	}

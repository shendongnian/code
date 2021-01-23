    [Test]
	[Category(Helper.TEST_CATEGORY_SAVE_GAME_STATE)]
	public void SaveTest_SetBuildTypeToWebAndRunSave_PassesIfSaveFunctionCalledSaveForWebFunction ()
	{
		// arrange
		Helper.BUILD_TYPE = Helper.BUILD_FOR_WEB;
		var slgdController = FakeSaveLoadGameDataController();
			
		// act
		slgdController.ClearReceivedCalls();
		slgdController.Save();
			
		// assert
		slgdController.Received().SaveForWeb();
	}
		
	[Test]
	[Category(Helper.TEST_CATEGORY_SAVE_GAME_STATE)]
	public void SaveTest_SetBuildTypeToX86AndRunSave_PassesIfSaveFunctionCalledSaveForX86Function ()
	{
		// arrange
		Helper.BUILD_TYPE = Helper.BUILD_FOR_WIN_X86;
		var slgdController = FakeSaveLoadGameDataController();
			
		// act
		slgdController.ClearReceivedCalls();
		slgdController.Save();
			
		// assert
		slgdController.Received().SaveForX86();
			
		Helper.BUILD_TYPE = Helper.BUILD_FOR_WEB;
	}

    public IAsyncOperation<UpdateGUIObj> setSelectedGUICellValueAsync(int arg1, int arg2, String cssId, bool isInitializeCbxChecked)
    {
      return SetSelectedGuiCellValueAsync(arg1, arg2, cssId, isInitializeCbxChecked).AsAsyncOperation();
    }
    private async Task<UpdateGUIObj> SetSelectedGuiCellValueAsync(int arg1, int arg2, String cssId, bool isInitializeCbxChecked)
    {
      updateGUIObj = new UpdateGUIObj();
      await Task.Run(....);
      return updateGUIObj;
    }

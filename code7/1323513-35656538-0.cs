    ...
    var updateGUIObj = await setSelectedGUICellValueAsync(arg1, arg2, cssId, isInitializeCbxChecked);
    ...
    public async Task<UpdateGUIObj> setSelectedGUICellValueAsync(int arg1, int arg2, String cssId, bool isInitializeCbxChecked)
    {
        var updateGUIObj = new UpdateGUIObj();
        // .... compute intensive work setting "updateGUIObj" 
        return updateGUIObj;
    }

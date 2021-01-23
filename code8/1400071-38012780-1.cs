    public async Task ConsumeAsync()
    {
        var _validChapterCodesTask = gd.validateChapterCodeDetails(_input1);
    
        await Task.WhenAll(_validChapterCodesTask);
    
        var _chapterCodeResult = _validChapterCodesTask.Result;
        // Do something with it...
    }

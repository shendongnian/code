    [Fact]
    public async Task CanDeleteAllTempFiles() {
        var exception = await Record.ExceptionAsync(() => DocumentService.DeleteAllTempDocuments());
        Assert.Null(exception);
    }

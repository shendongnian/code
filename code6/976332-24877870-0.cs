    public void Save_ReturnSavedDocument()
    {
        // (unmodified code)...
        //Assert that properties are correctly mapped after save
        Assert.AreEqual(
            new
            {
                repoResult.Message,
                repoResult.DocumentId,
                repoResult.Name,
                repoResult.Email,
                repoResult.Comment,
            },
            new
            {
                savedDocument.Message,
                savedDocument.DocumentId,
                savedDocument.Name,
                savedDocument.Email,
                savedDocument.Comment,
            });
    }

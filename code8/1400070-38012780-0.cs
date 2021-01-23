    public Task<IEnumerable<ChapterCodeValidationOutput>> 
        validateChapterCodeDetails(GroupMembershipValidationInput gmvi)
    {
         var rep = new Repository();
         return gmvi._chapterCodes.All(x => x.Equals(""))
             ? new List<ChapterCodeValidationOutput>()
             : rep.ExecuteStoredProcedureAsync
                   <Entities.Upload.ChapterCodeValidationOutput>
                       (SQL.Upload.UploadValidation
                                  .getChapterCodeValidationSQL(gmvi._chapterCodes),null)
    }

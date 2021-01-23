    public virtual ObjectResult<usp_GetAppropriatenessQuestionsWithMetadata_Result> usp_GetAppropriatenessQuestionsWithMetadata(Nullable<int> languageId)
        {
            var languageIdParameter = languageId.HasValue ?
                new ObjectParameter("LanguageId", languageId) :
                new ObjectParameter("LanguageId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_GetAppropriatenessQuestionsWithMetadata_Result>("usp_GetAppropriatenessQuestionsWithMetadata", languageIdParameter);
        }

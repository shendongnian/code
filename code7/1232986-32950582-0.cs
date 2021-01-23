    public List<SbtKlasorViewModel> GetFoldersWithIndexedDocuments()
    {
        using (var session = DatabaseProvider.SessionFactory.OpenSession())
        {
            var foldersContainingIndexedDocs = session.QueryOver<SbtKlasorModel>()
                .JoinQueryOver<DokumanlarModel>(x => x.DokumanlarList)
                    .Where(doc => doc.IndexlenmeTarihi != null)
                .List();
            //Transforming SbtKlasorModel to SbtKlasorViewModel for respose
            return folders.Select(ModelTransformer.TransformModel).ToList();
        }
    }

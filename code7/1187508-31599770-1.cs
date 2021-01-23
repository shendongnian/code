    public  class   Presentation<TPresentationModel, TDALModel, TMapper>
            where   TMapper : Presentation<TPresentationModel, TDALModel, TMapper>.BaseMapper
    {
        public  abstract    class   BaseMapper
        {
            public  abstract    TDALModel           ConvertPresentationModelToDALModel(TPresentationModel presentationModel);
            public  abstract    TPresentationModel  ConvertDALModelToPresentationModel(TDALModel dalModel);
        }
    }

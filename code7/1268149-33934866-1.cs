    public class DocHandler : ChainHandler
    {
        private readonly DocHelper docHelper; 
        public DocHandler(DocHelper docHelper)
        {
            Log = new LogWrapper(this); 
            this.docHelper = docHelper;
        }
        // ...
        public oAPI GetModel(int DocId)
        {
            var Model = docHelper.GetDoc();
            return RB(HTTPCodes.OK, data: Serializer(
            Model));
        }
        // ...
    }

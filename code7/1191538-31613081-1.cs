    public class US_ETDocumentImporter : BaseImporter<US_ETDocument,JETFileData>
    {
        public List<IBaseReader<JETFileData>> Readers { get; set; }
    
        public US_ETDocumentImporter()
        {
            this.Readers = new List<IBaseReader<JETFileData>>()
            {
                new ExcelFileReader()
            };   
        }
    
        //HERE IS WHERE I GOT THE ERROR!!!
        protected override IBaseReader<JETFileData> GetReader(Stream file, params object[] args)
        {
            //decide which reader is able to be used to process this file
            return this.Readers.Single(r => r.CanHandleStream(file, args));
        }
    }

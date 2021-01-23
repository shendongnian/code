    public class DModel
    {
        public string Name { get; set; }
    }
    public class CModel
    {
        public string SomeName { get; set; }
    }
    public class BModel
    {
        public List<DModel> DModels { get; set; }
        public BModel()
        {
            DModels = new List<DModel>();
        }
    }
    public class AModel
    {
        public BModel BModel { get; set; }
        public CModel CModel { get; set; }
        public string PostType { get; set; }
        public AModel()
        {
            BModel = new BModel();
            CModel = new CModel();
        }
    }

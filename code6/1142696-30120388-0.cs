            static DTO dto = new DTO();
            static void Main(string[] args)
            {
                List<KeyDriver> keyDrivers = new List<KeyDriver>();
                List<KeyDriver> result = keyDrivers.Where(x => x.KeyDriverModelId > 1000).ToList();
                foreach (var kd in dto.KeyDriverModels)
                {
                    var keyDriverModelNodeValue = result.SingleOrDefault(x => x.KeyDriverModelId == kd.ID);
                    kd.SelectionStatus = keyDriverModelNodeValue != null ?
                                           keyDriverModelNodeValue.SelectionStatus : string.Empty;
                }
                //new code
                var kd1 = from r in result
                          join d in dto.KeyDriverModels
                          on r.KeyDriverModelId equals d.ID  into drs
                          from dr in drs
                          select new { dr }.dr.SelectionStatus != null ? dr.SelectionStatus : string.Empty;
            }
        }
        public class DTO
        {
            public List<KeyDriverModel> KeyDriverModels { get; set; }
        }
        public class KeyDriverModel
        {
            public int ID { get; set; }
            public string SelectionStatus { get; set; }
        }
        public class KeyDriver
        {
            public int KeyDriverModelId { get; set; }
            public string SelectionStatus { get; set; }
        }
    ​

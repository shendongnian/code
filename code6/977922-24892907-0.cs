    [ServiceContract]
    public class ChaosService 
    {
        private static string connectionString;
    
        static ChaosService(){
            connectionString = your logic...
        }
    
        [OperationContract]
        public IEnumerable<Encountertime> GetEncounterTimes(DateTime? encountertime)
        {
            using (var context = new ChaosModel(connectionString))
            {
               ...
            }
        }
    }

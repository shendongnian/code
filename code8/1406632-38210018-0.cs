    public class Reference_ManufacturersController : ApiController
    {
        private DataEntities db = new DataEntities();
        static string _address = "http://localhost:57454/api/Reference_Manufacturers?format=json";
        private List<Reference_Manufacturers> result;
        // GET: api/Reference_Manufacturers
        public async Task<IEnumerable<Reference_Manufacturers>> GetReference_Manufacturers()
        {
            List<Reference_Manufacturers> resultset = await GetResponse();
            foreach (Reference_Manufacturers manu in resultset)
            {
                db.Reference_Manufacturers.Add(manu);
            }
            await db.SaveChangesAsync();
            return db.Reference_Manufacturers;
        }
        private async Task<List<Reference_Manufacturers>> GetResponse()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_address);
            response.EnsureSuccessStatusCode();
            result = await response.Content.ReadAsAsync<List<Reference_Manufacturers>>();
            return result;
        }}

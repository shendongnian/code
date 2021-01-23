        public void Main(string[] args)
        {
            string strBR = "[{ 'Id':763886,'AliasName':'ABC-3594'},{ 'Id':763759,'AliasName':'ABC-6789'},{ 'Id':763661,'AliasName':'ABC-9111'},{ 'Id':763668,'AliasName':'ABC-9111'},{ 'Id':764467,'AliasName':'ABC-3594'}]";
            string strBD = " [{'Id':763886,'AliasName':'ABC-3594'},{'Id':763759,'AliasName':'ABC-6789'},{'Id':764467,'AliasName':'ABC-3594'}]";
            var resultBR = JsonConvert.DeserializeObject<List<BeneficiaryResponse>>(strBR);
            var resultBD = JsonConvert.DeserializeObject<List<BeneficiaryDetail>>(strBD);
            var missingData = resultBR.Where(x => !resultBD.Select(n => n.Id).Contains(x.Id)).ToList();
            foreach (var item in missingData)
            {
                Console.WriteLine(item.Id);
            }
        }
        public class BeneficiaryResponse
        {
            public int Id { get; set; }
            public string AliasName { get; set; }
        }
        public class BeneficiaryDetail
        {
            public int Id { get; set; }
            public string AliasName { get; set; }
        }

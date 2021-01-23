        class Program
    {
        static void Main(string[] args)
        {
            VariantsEntities db=new VariantsEntities();
            
            var queryResult = db.Variants.AsEnumerable().Select(x => new PageViewModel
            {
                ParentVariant = x.Name,
                Type = x.Type,
                CustomSubvariantList = GetCustomSubVariants(x.Id,db).ToList()
            }).ToList();
           
            var jsonObj = JsonConvert.SerializeObject(queryResult);
            Console.WriteLine(jsonObj);
            Console.ReadKey();
        }
        private static IEnumerable<Customsubvariantlist> GetCustomSubVariants(int variantId, VariantsEntities db)
        {
            var subVariants = db.SubVariants.ToList();
            foreach (var subVariant in subVariants)
            {
                var obj=new Customsubvariantlist();
                obj.Name = subVariant.Name;
                var testOpTarget = db.TestOperations
                    .FirstOrDefault(x => x.TargetSubVariantId == subVariant.Id);
                var testOpSource = db.TestOperations
                    .FirstOrDefault(x => x.SourceSubVariantId == subVariant.Id);
                if (subVariant.VariantId == variantId)
                {
                    obj.Value = testOpTarget == null ? 
                        testOpSource?.SourceValue : testOpTarget?.TargetValue;
                    obj.DiffPerc = testOpTarget?.DiffPerc;
                }
                else
                {
                    obj.Value = null;
                    obj.DiffPerc = null;
                }
                yield return obj;
            }
        }
    }

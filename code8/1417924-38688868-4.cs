       public class CustomerVariantDTO
        {
            public String Type;
            public String ParentVariant;
            public IEnumerable<CustomerSubVariantDTO> CustomSubvariantList;
        }
        public class CustomerSubVariantDTO
        {
            public int? VariantId;
            public int? SourceId;
            public int? TargetId;
            public String Name;
            public Decimal? DiffPerc;
        }
        sealed class CustomerSubVariantDTOComparer : IEqualityComparer<CustomerSubVariantDTO>
        {
            public int GetHashCode(CustomerSubVariantDTO obj)
            {
                return 0;
            }
            public bool Equals(CustomerSubVariantDTO x, CustomerSubVariantDTO y)
            {
                return x.SourceId == y.SourceId &&
                       x.TargetId == y.TargetId &&
                       x.Name == y.Name &&
                       x.DiffPerc == y.DiffPerc;
            }
        }
        public void DoTestOfCustomerVariantDTO()
        {
            int testId = 1;
            using (var context = new VariantsEntities())
            {
                var query =
                  (from v in context.Variants
                   where v.Type == "Add"
                   select new CustomerVariantDTO
                   {
                       ParentVariant = v.Name,
                       Type = v.Type,
                       CustomSubvariantList =
                       (
                         from sv in context.SubVariants.Select(sv => sv)
                         join x in
                         (
                             from svparent in v.SubVariants
                             from to in svparent.TestOperation
                             where to.TestId == testId
                             select new
                             {
                                 svparent.Name,
                                 to.DiffPerc,
                                 SourceId = (int?)to.SubVariants.Id ?? 0,
                                 TargetId = (int?)to.SubVariants1.Id ?? 0
                             }
                         )
                         on sv.Name equals x.Name into g
                         from x in g.DefaultIfEmpty()
                         select new CustomerSubVariantDTO{
                             VariantId = sv.VariantId,
                             SourceId = (int?)x.SourceId ?? sv.TestOperation.Select(to => to.SourceSubVariantId).FirstOrDefault(),
                             TargetId = (int?)x.TargetId ?? sv.TestOperation.Select(to => to.TargetSubVariantId).FirstOrDefault(),
                             Name = sv.Name,
                             DiffPerc = x.DiffPerc
                         }
                      ).OrderBy(csv => new { csv.VariantId, csv.Name })
                   }).ToList();
                var listCustomVariants =
                    query.Select(v => new{
                        Type = v.Type,
                        ParentVariant = v.ParentVariant,
                        CustomSubvariantList = v.CustomSubvariantList.Distinct(new CustomerSubVariantDTOComparer()).ToList()
                    });
                foreach (var item in listCustomVariants){
                    Console.WriteLine($"Type: {item.Type} - ParentVariant: {item.ParentVariant} ");
                    foreach (var csubvar in item.CustomSubvariantList)
                        Console.WriteLine($"SourceId: {csubvar.SourceId} - TargetiId: {csubvar.TargetId} - NAme: {csubvar.Name} - DiffPerc: {csubvar.DiffPerc} ");
                }
            }
        }

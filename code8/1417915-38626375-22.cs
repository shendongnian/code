    static void Main(string[] args)
        {
            VariantsEntities db = new VariantsEntities();
            var result = from x in db.Variants                        
                         select new PageViewModel
                         {
                             ParentVariant = x.Name,
                             Type = x.Type,
                             CustomSubvariantList = (from z in db.SubVariants
                                                     let testOpTarget=z.TestOperations1
                                                            .FirstOrDefault(q=>q.TargetSubVariantId==z.Id)
                                                     let testOpSource=z.TestOperations
                                                            .FirstOrDefault(q=>q.SourceSubVariantId==z.Id)
                                                     select new Customsubvariantlist
                                                     {
                                                         Name = z.Name,
                                                         Value = x.Id==z.VariantId? 
                                                                 testOpTarget.TargetValue??
                                                                 testOpSource.SourceValue:null,
                                                         DiffPerc = x.Id==z.VariantId? 
                                                                    testOpTarget.DiffPerc:null
                                                     }).ToList()
                         };
            var json = JsonConvert.SerializeObject(result.ToList());
            Console.WriteLine(json);
            Console.ReadKey();
        }

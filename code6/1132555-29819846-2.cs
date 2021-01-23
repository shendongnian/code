    IEnumerable<TestForms.Models.v_HmsUnacceptedForms> result = data.GroupBy(x => x.id)
                     .ToList()   //To force run projection in memory.
                     .Select(x => 
                   {
                         var firstRecord = x.FirstOrDefault();
                         return new TestForms.Models.v_HmsUnacceptedForms
                        {
                           id = x.Key,
                           name = firstRecord != null ? firstRecord.name : String.Empty,
                           email = firstRecord != null ? firstRecord.email: String.Empty,
                           roles = String.Join(",",x.Select(z => z.roles),
                           modules = firstRecord != null ? firstRecord.modules : String.Empty
                        };
                   });
                    

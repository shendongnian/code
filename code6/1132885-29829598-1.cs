    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace UnitTestProject2
    {
        public class Class8
        {
            public class ParentModel
            {
            }
    
            public class ChildModel
            {
                public int Id { get; set; }
            }
            public void GetParentsWithNoChildern()
            {
                Dictionary<ParentModel, List<ChildModel>> parentDictionary = new Dictionary<ParentModel,List<ChildModel>>();
                Dictionary<int, bool> selectedChildIds = new Dictionary<int, bool>();
    
                List<ParentModel> parentsWithNoChildern = 
                    parentDictionary
                    .Where(
                        p => p.Value
                                .Where(c => selectedChildIds.Any(sc => sc.Key == c.Id && sc.Value == true))
                                .Count() == 0
                        )
                    .Select(k => k.Key)
                    .ToList();
            }
        }
    }

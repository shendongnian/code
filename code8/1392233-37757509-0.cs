      var data1 =  JObject.Parse(@"{
               'data':[
              {
                 'ID':'53a1862000404a304942546b35519ba3',
                  'name':'Private Approval Process: Draft Document CPL',
                  'objCode':'ARVPTH'
              }]
            }");
            var data2 = JObject.Parse(@"{
               'data':[
              {
                 'ID':'53a1862000404a304942546b35519ba3',
                  'name':'Private Approval Process: Draft Document CPL',
                  'objCode':'ARVPTH'
              }]
            }");
            data1.Merge(data2, new JsonMergeSettings
            {
               MergeArrayHandling = MergeArrayHandling.Union
            });
            string json = data1.ToString();

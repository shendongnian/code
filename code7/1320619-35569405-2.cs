     IList<AccountsManagement> yourData = JsonConvert.DeserializeObject<List<AccountsManagement>>(yourJsonString);
        
     IList<YourResult> finalResult =  yourData.GroupBy(m => m.Name, m =>m.IDNO).Select(group => new YourResult(){
           Name = group.FirstOrDefault().Name,
           IDNO = group.FirstOrDefault().IDNO,
           Data_cnt = group.Count
        }).ToList();

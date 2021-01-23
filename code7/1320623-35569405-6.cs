     IList<AccountsManagement> yourData = JsonConvert.DeserializeObject<List<AccountsManagement>>(yourJsonString);
        
     IList<YourResult> finalResult =  yourData.GroupBy(m => new {m.Name, m.IDNO).Select(group => new YourResult(){
           Name = group.FirstOrDefault().Name,
           IDNO = group.FirstOrDefault().IDNO,
           Data_cnt = group.Count()
        }).ToList();

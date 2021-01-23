     var grouped =
       result.GroupBy(o => o.CREATE_USER_ID).Select(agent => new
        {
            data = new List<List<object>>
            {
                new List<object>
                {
                    agent.Key != null ? string.Format("{0}", agent.Key).Replace("SAGANTGB\\", "") : null,
                    agent.Count()
                }
            },
            color = "yellow"
        }).ToList();
    
    return Json(grouped, JsonRequestBehavior.AllowGet);

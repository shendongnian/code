    var json = JsonConvert.SerializeObject(
        new
        {
            User = new JsonUser
            {
                inQuery = new
                {                            
                    where = new { firstName = plf.UserName}
                }
            }
        });

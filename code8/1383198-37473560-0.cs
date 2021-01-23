    var json = JsonConvert.SerializeObject(
        new
        {
            User = new
            {
                inQuery = new
                {
                    where = new {firstName = plf.UserName}
                }
            }
        });

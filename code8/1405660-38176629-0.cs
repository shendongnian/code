    private void GetInfoFromRedis(object sender, EventArgs e) 
    {
        using (var client = RedisManager.GetClient()) 
        {
            client.Set<Human>("RedisKey", new Human { 
                Age = 29,
                Height = 170,
                Name = "HumanName"
                });
            }
        }
    }

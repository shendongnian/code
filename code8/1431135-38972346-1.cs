    DateTime beginDate = DateTime.Now;
    Debug.WriteLine("查询1开始");`  
    Website site = WebsiteRedis.GetByCondition(w => w.Name == "网址2336677").First();
    double time = (DateTime.Now - beginDate).TotalMilliseconds;
    Debug.WriteLine("耗时：" + time + "ms");
            
    DateTime beginDate2 = DateTime.Now;
    Debug.WriteLine("查询2开始");
    Website site2 = WebsiteRedis.GetByID(new Guid("29284415-5de0-4781-bea4-5e01332814b2"));
    double time2 = (DateTime.Now - beginDate2).TotalMilliseconds;
    Debug.WriteLine("耗时：" + time2 + "ms");

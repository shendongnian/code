            var models = (from em in employeeModels
                          group em by em.ID into g
                          select new
                          {
                              Id = g.Key,
                              maxDate = g.Max(p => p.Date)
                          }).ToList();
            var result = new
            {
                date = prices.Max(p => p.maxDate),
                SkillssetPoints = prices.Select(p => p.Id).ToList()
            };
            var json = JsonConvert.SerializeObject(result);

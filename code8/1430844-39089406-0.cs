            EntityRecommendation entityDate;
            EntityRecommendation entityTime;
            result.TryFindEntity("builtin.datetime.date", out entityDate);
            result.TryFindEntity("builtin.datetime.time", out entityTime);
            if ((entityDate != null) & (entityTime != null))
                entities.Add(new EntityRecommendation(type: "DateTime") { Entity = entityDate.Entity + " " + entityTime.Entity });
            else if (entityDate != null)
                entities.Add(new EntityRecommendation(type: "DateTime") { Entity = entityDate.Entity });
            else if (entityTime != null)
                entities.Add(new EntityRecommendation(type: "DateTime") { Entity = entityTime.Entity });

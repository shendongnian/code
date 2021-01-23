            List<UpdateOneModel<Entity>> requests = new List<UpdateOneModel<Entity>>(entities.Count());
            foreach (var entity in entities)
            {
                var filter = new FilterDefinitionBuilder<Entity>().Where(m => m.Field1 == entity.Field1 && m.Field2== entity.Field2);
                var update = new UpdateDefinitionBuilder<Entity>().Set(m => m.Field1, entity.Field1).Set(m => m.Field2, entity.Field2);
                var request = new UpdateOneModel<Entity>(filter, update);
                request.IsUpsert = true;
                requests.Add(request);
            }
            await Collection.BulkWriteAsync(requests);

    var baseFilter = Builders<Project>.Filter.Eq("ProjectID": 1);
    var update = Builders<Project>.Update.Set("ProjectTasks.$[i].Comments.$[j].CommentDescription", comment.CommentDescription);
    
    var arrayFilters = new List<ArrayFilterDefinition>
    {
        /* change the type names here if they have different names, I just guessed */
        new BsonDocumentArrayFilterDefinition<ProjectTask>(new BsonDocument("i.ProjectTaskID", projectTaskID)),
        new BsonDocumentArrayFilterDefinition<Comment>(new BsonDocument("j.CommentId", commentID))
    };
    
    var updateOptions = new UpdateOptions { ArrayFilters = arrayFilters };
    
    await Collection.UpdateOneAsync(baseFilter, update, updateOptions);

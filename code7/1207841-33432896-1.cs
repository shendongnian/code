        static QueryDefinition GetQueryDefinitionFromPath(QueryFolder folder, string path)
        {
            return folder.Select<QueryItem, QueryDefinition>(item =>
            {
                return item.Path == path ?
                    item as QueryDefinition : item is QueryFolder ?
                    GetQueryDefinitionFromPath(item as QueryFolder, path) : null;
            })
            .FirstOrDefault(item => item != null);
        }

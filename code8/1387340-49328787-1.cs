     public async Task<IEnumerable<object>> GetFiles(int parentId)
        {
            var data = await Task.Run(()=> from file in DB.Files
                       where file.ParentId == parentId
                       select new { name = file.Name, id = file.Id }).ToList();
            return data;
        }

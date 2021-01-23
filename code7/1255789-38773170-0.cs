            public static IQueryable<MyDto> QueryableFromTaskType1(
            IQueryable<TaskType1> query)
        {
            return query.Select(src => new MyDto()
            {
                TaskId = src.Id,
                AssetTypeName = src.Asset.AssetType.Name,
                AssetId = src.Asset.Id,
                AssetCode = src.Asset.Code,
                AssetName = src.Asset.Name,
            });
        }
            public static IQueryable<MyDto> QueryableFromTaskType2(
            IQueryable<TaskType2> query)
        {
            return query.Select(src => new MyDto()
            {
                TaskId = src.Id,
                AssetTypeName = src.AssetTypeName,
                AssetId = src.AssetId,
                AssetCode = src.AssetCode,
                AssetName = src.AssetName,
            });
        }

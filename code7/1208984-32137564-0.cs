    .Project(root => 
        new Root2 {
            ezBaseId = root.EzBaseId,
            classificationId = root.Id.ClassificationId,
            name = root.Id.Name,
            specification = root.Id.Specification,
            img = root.Id.Image,
            articles = root.Articles,
            supplier = root.Id.Supplier
        });

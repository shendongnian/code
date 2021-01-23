    class JobSubCategoryModel : JobCategoryModel { }
    // ...
    ChildCategories =  x.SubCategory.Select(y => new JobSubCategoryModel
    {
        CategoryName = y.CategoryName,
        Identifier = y.Identifier,
        ImagePath = y.Images != null ? imagePath + "/" + y.Images.ImagePath : null,
    })
 

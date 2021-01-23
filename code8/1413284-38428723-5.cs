    List<Category> list = new List<Category>();
    while (reader.Read())
    {
        Category category = new Category() {
          CategoryID = Convert.ToInt32(reader["CategoryID"]);
          CategoryName = reader["CategoryName"].ToString();
          ImageURL = reader["ImageURL"].ToString()
        }
        list.Add(category);
        CategoryEnt detailedCategory = new CategoryEnt() {CategoryPrimaryDetails = category};
     }

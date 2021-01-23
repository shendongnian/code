    private void cbListFirst_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        // Clear second CheckedListbox DataSource
        cbListSecond.DataSource = null;
        var ingridients = new List<Ingridient>();
        foreach (var item in cbListFirst.CheckedItems)
        {
            // If item was previously checked, we want to skip it because it's new value is
            // unchecked and we shouldn't be adding it's child items to second CheckedListbox
            if (cbListFirst.Items.IndexOf(item) != e.Index)
            {
                var foodType = (FoodType)item;
                ingridients.AddRange(GetIngridientsForFoodType(foodType.Id));
            }
        }
        // If item was previously unchecked, it's child items won't be caught in previous loop
        // so we want to explicitly include them inside this if-block if new value is checked
        if (e.NewValue == CheckState.Checked)
        {
            var foodType = (FoodType)cbListFirst.Items[e.Index];
            ingridients.AddRange(GetIngridientsForFoodType(foodType.Id));
        }
        // Finally, bind new DataSource
        cbListSecond.DataSource = ingridients;
        cbListSecond.DisplayMember = "Name";
        cbListSecond.ValueMember = "Id";
    }
    // This method returns list of Ingridients for single FoodType
    private List<Ingridient> GetIngridientsForFoodType(int foodTypeId)
    {
        using (var con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT Id, Name
                                FROM dbo.Ingridients
                                WHERE FoodTypeId = @FoodTypeId";
            cmd.Parameters.AddWithValue("@FoodTypeId", foodTypeId);
            try
            {
                con.Open();
                var ingridients = new List<Ingridient>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ingridients.Add(new Ingridient()
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"] as string
                        });
                    }
                }
                return ingridients;
            }
            catch (Exception ex)
            {
                // Handle error (should be improved) and return null
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }

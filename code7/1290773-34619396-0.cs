    try
    {
    using (DataBase context = new DataBase())
    {            
           Products item = new Products();
           item.Title = title.Text;
           item.Subtitile = subtitle.Text;
           item.Description = description.Text;
           item.Price = float.Parse(price.Text);
           context.Products.Add(item);
           context.SaveChanges();
           MessageBox.Show("Product successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
           title.Clear();
           subtitle.Clear();
           description.Clear();
           price.Clear();
    }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private async Task TypeCategoryAdd (string table, string item)
    {
        if (string.IsNullOrEmpty(item)) return;
    
        using (MenuGenerator.NewArchMenuGeneratorEntities con = new NewArchMenuGeneratorEntities())
        {
            switch (table)
            {
                case "OfferType":
                    if (await con.OfferTypes.AnyAsync(x=>x.Name == item))
                    {
                        MessageBox.Show("There is already a " + item + " on the list!");
                        tbOfferType.Text = "";
                        return;
                    }
                    OfferType ot = new OfferType();
                    ot.Name = item;
                    con.OfferTypes.Add(ot);
                    try
                    {
                        await con.SaveChangesAsync();
                        tbOfferType.Text = "";
                        lstOfferType.DataSource = await con.OfferTypes.OrderBy(x=>x.Id).ToListAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex.ToString());
                    }
                    break;                
    
                }
                return;
            }
        }
    }

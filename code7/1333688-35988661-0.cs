    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gvExOr.Rows[e.RowIndex];
        var pizzaId = gvExOr.DataKeys[e.RowIndex].Values[0];  // Set this in markup of grid
        string size = (row.FindControl("txtSize") as TextBox).Text;  // Assumes you have EditItemTemplate
        using (PizzaParlor2Entities entities = new PizzaParlor2Entities ())
        {
            Pizza pizza = entities.Pizzas.First(p => p.PizzaID == pizzaID);
            pizza.Size = size;
            entities.SaveChanges();
        }
        gvExOr.EditIndex = -1;
        this.BindGrid();
    }

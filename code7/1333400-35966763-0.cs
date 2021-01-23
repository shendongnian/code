    using (PizzaParlor2Entities po = new PizzaParlor2Entities())
    {
        var PizzaID = Convert.ToInt32(gvExOr.Rows[e.RowIndex].Cells[0].Text.ToString());
        var oldPizza = po.Pizza.Find(PizzaID); // retrieve the object by the id
        // update the needed data
        oldPizza.Price =  gvExOr.Rows[e.RowIndex].Cells[1].Text.ToString();
        //save changes to DB
        po.SaveChanges();
    }

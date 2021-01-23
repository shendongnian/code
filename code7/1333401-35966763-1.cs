    using (PizzaParlor2Entities po = new PizzaParlor2Entities())
    {
        var PizzaID = Convert.ToInt32(gvExOr.Rows[e.RowIndex].Cells[0].Text.ToString());
        po.Pizza.Delete(p => p.PizzaID == PizzaID); // delete the object by the id
        //save changes to DB
        po.SaveChanges();
    }

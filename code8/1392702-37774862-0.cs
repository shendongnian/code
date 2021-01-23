    <%: Html.ActionLink("Rent Book", "RentBooks", "Book", new { new RentBook {id = 123, name="ddd"} }, null)%>
     public ActionResult RentBooks (RentBooks rb)
     {
         db.RentBooks.Add(rb);
         return View();
     }

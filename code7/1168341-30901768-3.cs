    @using (Html.BeginForm("Boat", "Shipments"))
    {
        <input type="submit" name="submitButton" value="Search" />
        <input type="submit" name="submitButton" value="Reset" />
    }
    
    public ActionResult Shipments(FormCollection form) 
    {
        if(form["submitButton"] == "Reset") {
            // reset was pressed
            Session.Remove("SearchBoat"); // remove session
            return RedirectToAction("Index"); // redirect
        }
        // submit was pressed
    }

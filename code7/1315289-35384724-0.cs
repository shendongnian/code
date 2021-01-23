      var clientList = new PaymentsViewModel
        {
            int selectedID = "the selected clientID";
            Clients = new SelectList(db.ClientsList, "ClientsId", "ClientsName", selectedID)
        };
        return View(clientList);

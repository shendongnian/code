    public PartialViewResult ClientSearch(ClientViewModel data)
    {
        var model = new ClientViewModel();
        model.ClientsCollection = _ClientService.Get(u => ((data.SearchString == "" || u.FullName.Contains(data.SearchString)) && (data.SelectedClientStatus == null || u.StatusID == data.SelectedClientStatus) && (data.SelectedLocation == null || u.LocationID == data.SelectedLocation)), null, "ClientsProfile, ClientsMobiles").ToList();
        return PartialView("_ClientsResult", model);
    }

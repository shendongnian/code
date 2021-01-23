    public ActionResult GetImageOffer(string oid, string otr)
    {
        var client = new RestClient("valid url");
        var request = new RestRequest("/Offer/OfferDirect", Method.POST);
        request.AddQueryParameter("oid", oid);
        request.AddQueryParameter("otr", otr);
        request.AddHeader("apikey", "secretkeyhere");
        request.RequestFormat = DataFormat.Json;
        RestResponse<RootObject> response = client.Execute<RootObject>(request);
        return PartialView("_pImageOfferModel", response.Data);
    }

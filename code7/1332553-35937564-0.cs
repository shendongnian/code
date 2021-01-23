    var json = "{\"AccountId\": 12345665555, \"InvoicId\": 1235, \"Addresses\": [[\"10 Watkin , , , , , Northampton, Northamptonshire\"], [\"12 Spencer Terrace, , , , , Northampton, Northamptonshire\"], [\"18 Watkin , , , , , Northampton, Northamptonshire\"], [\"22 Watkin , , , , , Northampton, Northamptonshire\"]] }";
    var addressList = JsonConvert.DeserializeObject<AddressResult>(json);
    private class AddressResult
    {
        public string AccountId { get; set; }
        public string InvoiceId { get; set; }
        public List<List<string>> Addresses { get; set; }           
    }

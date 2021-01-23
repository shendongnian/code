    public string TrackingNumberHyperLink {
    get
     {
        return  GetTrackingURL(this.ShippingCarrier, this.TrackingNumber)
     }
    }

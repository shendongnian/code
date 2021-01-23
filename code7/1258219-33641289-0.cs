    [Serializable]
    [XmlRoot(ElementName = "po-response", Namespace = "http://seller.marketplace.sears.com/oms/v11")]
    public class SearsPurchaseOrderResponseModel
    {
    	[XmlElement("deprecated")]
    	public DateTime Deprecated { get; set; }
    
    	[Required]
        // [XmlArrayItem("purchase-order")]
    	[XmlElement("purchase-order")]
    	public List<SearsPurchaseOrderModel> PurchaseOrder { get; set; }
    }

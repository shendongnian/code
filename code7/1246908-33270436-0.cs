    [Serializable]
    public class MaybankeBPGResponse
    {
        [XmlElement("TRANSACTION_ID")]
        public string MaybankeBPGTxnId { get; set; }
        [XmlAttribute("MERCHANT_TRANID")]
        public string MerchantTxnId { get; set; }
        [DefaultValueAttribute(typeof(System.DateTime), "1901-01-01")]
        [XmlElement("TRAN_DATE")]
		[EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		[System.ComponentModel.BrowsableAttribute(false)]
        public DateTime? AuthDateForSerialization { get; set; }
        public DateTime? AuthDate { 
			get {
				return String.IsNullOrEmpty(AuthDateForSerialization) ? null : DateTime.ParseExact(AuthDateForSerialization, "yyyy-MM-dd", CultureInfo.InvariantCulture);
			}
			set {
				AuthDateForSerialization = value.HasValue ? value.Value.ToString("yyyy-MM-dd") : String.Empty;
			}
		}
        [XmlElement("RESPONSE_CODE")]
        public string ResponseCode { get; set; }
    }

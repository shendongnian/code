	[Serializable, XmlRoot("Get_mouvements_usersResult", Namespace = "urn:DME_Webservices"), XmlType("Get_mouvements_usersResult", Namespace = "urn:DME_Webservices")]
	public class XmlUsers
	{
	    [XmlElement("tab_Cuser_mouvements", Namespace = "")]
	    public List<XmlUserMove> UserList { get; set; }
	
	    [XmlElement("Obj_info_retour", Namespace = "")]
	    public SoapResult soapResult { get; set; }
	}

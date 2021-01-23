	public string XMLDoc(SalesForecastModel model)
	{
		var xml =
			new XElement(
				"SalesForecast",
				new XElement(
					"header",
					new XElement("EntryNumber", model.EntryNumber),
					new XElement("EntryDate", model.EntryDate),
					new XElement("Year", model.Year),
					new XElement("Remarks", model.Remarks),
					new XElement("RevisionID", model.RevisionID),
					new XElement("Status", model.Status),
					new XElement("CreatedBy", model.CreatedBy),
					new XElement("CreatedDate", model.CreatedDate),
					new XElement("LastModifiedBy", model.LastModifiedBy),
					new XElement("LastModifiedDate", model.LastModifiedDate)),
				new XElement(
					"details",
					model.Details.Select(detail =>
						new XElement(
							"SalesForecastDetails",
							new XElement("MonthID", detail.MonthID)))));
							
		return xml.ToString();
	}

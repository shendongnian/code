	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	[Route("api/admin/UnitsOfMeasure/UnitOfMeasureRelatedUnitsCreate")]
	[HttpPost]
	[ResponseType(typeof(UnitsOfMeasure.UnitsOfMeasureDataWithMessage))]
	public IHttpActionResult UnitOfMeasureRelatedUnitsCreate([FromBody] JObject UnitOfMeasureRelatedUnitDataInbound)
	{
		var json = "[" + JsonConvert.SerializeObject(UnitOfMeasureRelatedUnitDataInbound) + "]";
		List<UnitsOfMeasure.UnitOfMeasureRelatedUnitDataInbound> plist = JsonConvert.DeserializeObject<List<UnitsOfMeasure.UnitOfMeasureRelatedUnitDataInbound>>(json);
		return Ok();
	}

    [RoutePrefix("Pickup")]
    [Route("{action=Create}")]
    public class PickupController : FrontOfficeAuthorizedController {
        [HttpPost]
        public JsonResult GetSenderAddress(Guid? addressId) {
            if(addreddId != null) {
                //Do something to get an address
                if(address != null) {
                    //Only send required info over the wire
                    return Json(new {
                            success = true,
                            address = new {
                                Address1 = address.Address1,
                                Address2 = address.Address2,
                                AddressType = address.AddressType,
                                CompanyOrName = address.CompanyOrName,
                                Contact = address.Contact,
                                Country = address.Country,
                                PostalCode = address.PostalCode,
                                Telephone = address.Telephone,
                                TownCity = address.TownCity,
                            }
                    });
                }
            }
            return Json(new { success = false });
        }
    }

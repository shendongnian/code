     public async Task<ActionResult> GetEnquiredData(string FirstName, string LastName, string Email, string PhoneNumber, string TravelCalendar, string TravelNights, string TravelMonth, string TNoAdults, string TNoChildren, string SpecialOc, string GettoKnow, string TCUKMember, string Tdate, string Tprice, string byemail, string dealRef, string ConTime)
     {
            var serverResponse = new ServerResponse();
            try { //Send Email here
            serverResponse.SuccessMessage = "Success!";
            }
            catch (Exception ex)
            {
            serverResponse.ErrorMessage= $"Error! + {ex.Message}";
            }
           return Json(serverResponse, JsonRequestBehaviour.AllowGet);
     }

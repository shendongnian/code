    [HttpGet]
    public SuccessResponse Save(BookingInformation BookingJson)
    {
        SuccessResponse msg = new SuccessResponse();
        msg.FleetBookingId = objMaster.Current.Id.ToString();
        msg.Success = true;
        msg.Message = "Booking saved successfully";
        
        return msg;
    }

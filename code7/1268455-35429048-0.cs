      public static void SendBookingConfirmation([ServiceBusTrigger("BookingCreated","SendConfirmation")] BookingCreated bookingDetails)
        {
            // lookup customer details from booking details 
            // send email to customer
        }
      public static void UpdateBookingHistory([ServiceBusTrigger("BookingCreated","UpdateBookingHistory")] BookingCreated bookingDetails)
        {
            // save booking details to CRM
        }

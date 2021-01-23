      public static void SendBookingConfirmation([ServiceBusTrigger("BookingCreated","SendConfirmation")] BookingCreatedEvent bookingDetails)
        {
            // lookup customer details from booking details 
            // send email to customer
        }
      public static void UpdateBookingHistory([ServiceBusTrigger("BookingCreated","UpdateBookingHistory")] BookingCreatedEvent bookingDetails)
        {
            // save booking details to CRM
        }

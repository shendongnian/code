    public class DeliveryVM
    {
      public int? ID { get; set; }
      [Required(ErrorMessage = "Please select the status")]
      public Status Status { get; set; }
      public SelectList StatusList { get; set; } // add this      
    }

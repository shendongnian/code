    public class BusRouteViewModel : IValidatableObject 
    {
        [Required(ErrorMessage = "Departure Terminal is required")]
        [Description("The starting terminal where the bus will move from")]
        [Display(Name = "Departure Terminal *")]
        public string DepartureTerminal { get; set; }
        [Display(Name = "Destination Terminal *")]
        [Description("The terminal the bus will stop at")]
        [Required(ErrorMessage = "Destination Terminal is required")]
        public string DestinationTerminal { get; set; }
        [Display(Name = "Bus Fare *")]
        [Description("The amount the route cost")]
        [Required(ErrorMessage = "Bus Fare is required")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid Amount")]
        public decimal BusFare { get; set; }
        [Display(Name = "Route Type *")]
        [Description("State if the route is a long journey or not")]
        [Required(ErrorMessage = "Route Type is required")]
        public string RouteType { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DepartureTerminal == DestinationTerminal)
                yield return new ValidationResult("Departure Terminal cannot be the same as Destination Terminal.", new[] { "DepartureTerminal", "DestinationTerminal" });
        }
    }

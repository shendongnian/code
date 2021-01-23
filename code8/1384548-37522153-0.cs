    public class PricedItinerary : AirItineraryPricingInfo
    {
        public int SequenceNumber { get; set; }
        public AirItinerary AirItinerary { get; set; }
        public List<AirItineraryPricingInfo> AirItineraryPricingInfo { get; set; }
        public TicketingInfo TicketingInfo { get; set; }
        public TPAExtensions7 TPA_Extensions { get; set; }
    }

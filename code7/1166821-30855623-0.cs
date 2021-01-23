    public class shippingInfo {
        public System.Guid EmailConfirmationId { get; set; }
        private Nullable<System.DateTime> fDeliveryDate;
        public Nullable<System.DateTime> DeliveryDate {
            get { return fDeliveryDate; }
            set {
                if (value.HasValue && value.Value.Kind != DateTimeKind.Utc) {
                    fDeliveryDate = value.Value.ToUniversalTime();
                }
                else {
                    fDeliveryDate = value;
                }
            }
        }
    }

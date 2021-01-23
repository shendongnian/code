    public class MyViewModel : IValidatableObject
    {
        public int? BossId { get; set; }
        public DateTime? HeadShipDate { get; set; }
    
        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            if( BossId.HasValue && !HeadShipDate.HasValue )
            {
                yield return new ValidationResult( "HeadShipDate is required if BossId is selected.", new[] { "HeadShipDate" } );
            }
        }
    }

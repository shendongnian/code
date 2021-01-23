     public class TestBool
    {
       
        [MustBeTrue(ErrorMessage = "Must be accepted")]
        public bool ConfirmEligibilityDocument { get; set; }
    }

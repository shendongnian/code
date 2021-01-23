	public class PaymentInput {
		// [Required] //removed Required unless you want a different message if nothing is provided
		[RegularExpression(@"^[0-9\.]+$", ErrorMessage = "ProductId must be an integer")] 
		// changed regex to + instead of * which forces it to have at least 1 passed in character
		public string ProductId { get; set; }
		public int GetProductId() { return int.Parse(ProductId); }
	}

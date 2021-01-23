    public class LoginConfirmation : Confirmation 
    {
        public string Login { get; set; }
        public SecureString SecurePassword { get; set; }
    }
    public InteractionRequest<LoginConfirmation> LoginConfirmationRequest { get; private set; }
    this.LoginConfirmationRequest = new InteractionRequest<LoginConfirmation>();

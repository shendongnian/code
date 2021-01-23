    public UserManager(Context context, 
                      [Named("Email")] IIdentityMessageService emailService,
                      [Named("Sms")] IIdentityMessageService smsService, 
                      IUserTokenProvider<User, string> tokenProvider = null)
       : base(new UserStore(context))

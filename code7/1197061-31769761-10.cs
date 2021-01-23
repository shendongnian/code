    public class HashValidated : Response<HashValidated>
    {
        public string passwordResetHash;
    }
    public class HashValidated : Response<HashValidated> {}
    public class PasswordResetHashExpired : Response<PasswordResetHashExpired> {}
    public class Unexpected : Response<Unexpected> {}

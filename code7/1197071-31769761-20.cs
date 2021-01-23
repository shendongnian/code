    public class HashValidated : Response<HashValidated>
    {
        public string passwordResetHash;
    }
    public class InvalidHash : Response<InvalidHash> {}
    public class PasswordResetHashExpired : Response<PasswordResetHashExpired> {}
    public class Unexpected : Response<Unexpected> {}

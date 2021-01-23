    public static class BasicAuthenticationExtensions {
        public static void UseBasicAuthentication(this IApplicationBuilder builder) {
            builder.UseMiddleware<BasicAuthenticationMiddleware>(new BasicAuthOptions());
        }
    }

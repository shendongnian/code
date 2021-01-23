    public static class IdentityExtensions{
        public static string Thumbnail(this IIdentity identity){
            try{
                return ((ClaimsIdentity) identity).FindFirst("Thumbnail").Value;
            }
             catch(Exception ex){
             // handle any exception the way you need
            }
        }
    }

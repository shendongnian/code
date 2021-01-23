    public class SearchResponseBuilder
    {
        public static SearchResponse Build(string errorMessage)
        {
            var ctors = typeof (SearchResponse).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            var neededCtor = ctors.First(
                ctor =>
                    ctor.GetParameters().Count() == 5);
            SearchResponse response = neededCtor.Invoke(new object[]
            {
                "distinguishedName",
                null, // System.DirectoryServices.Protocols.DirectoryControl[]
                null, // System.DirectoryServices.Protocols.ResultCode
                errorMessage,
                null // System.Uri[]
            }) as SearchResponse;
            return response;
        }
    }

    class Program
    {
        private readonly static Dictionary<SocialNetworks, Type> handlerMapping = new Dictionary<SocialNetworks, Type>()
                                                              {
                                                                  {SocialNetworks.Linkedin, typeof(Linkedin)},
                                                                  {SocialNetworks.Facebook, typeof(Facebook)},
                                                                  {SocialNetworks.Twitter, typeof(Twitter)},
                                                              };
        static void Main(string[] args)
        {
            HandleAnySocialNetworkByMapping(SocialNetworks.Facebook, new Facebook()).Wait();
            HandleAnySocialNetworkByMapping(SocialNetworks.Linkedin, new Linkedin()).Wait();
            HandleAnySocialNetworkByMapping(SocialNetworks.Twitter, new Twitter()).Wait();
        }
        private async static Task HandleAnySocialNetworkByMapping(SocialNetworks provider, object socialNetwork)
        {
            Type handler = handlerMapping[provider];
            var insertIfNotExistsMethodInfo = typeof(SocialRepository)
                .GetMethods()
                .First(m => m.Name == "InsertIfNotExists");
            await (Task)insertIfNotExistsMethodInfo.MakeGenericMethod(handler).Invoke(new SocialRepository(), new[] { socialNetwork });  
        }
    }

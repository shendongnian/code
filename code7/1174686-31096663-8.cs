    public class TwitchSampleImplementation
    {
        private IList<RestResponseCookie> _cookies;
        public void AuthenticateAndGetChannels()
        {
            // this is where your login credentials go which can be acquired here 
            // => https://github.com/justintv/Twitch-API/blob/master/authentication.md#developer-setup 
            Authenticate("yourClientId", "thatUrl", null, "thatState"); 
            var channels = GetChannel("popularChannel");
            Console.WriteLine(String.Format("Channels: ", channels.channels.Select(c =>
                c.display_name).Aggregate("", (a, b) => a + b + ",").TrimEnd(',')));
        }
        public void Authenticate(string clientId,
            string registeredRedirectURI, List<string> scopes, string state)
        {
            // reference: https://github.com/justintv/Twitch-API/blob/master/authentication.md
            var login = Tuple.Create("client_id", clientId);
            var redirectURI = Tuple.Create("redirect_uri", registeredRedirectURI);
            var theScope = Tuple.Create("scope", scopes.Aggregate("", (a, b) => a + b + ",").TrimEnd(','));
            var theState = Tuple.Create("state", state);
            // reference: baseUrl => https://github.com/justintv/Twitch-API#formats
            var client = new RestClient("https://api.twitch.tv/kraken/");
            var request = new RestRequest("oauth2/authorize", Method.POST); // try Method.GET if that doesn't work
            var type = ParameterType.GetOrPost;
            var paramList = new List<Parameter>()
            {
                new Parameter {Name = login.Item1, Value = login.Item2, Type = type},
                new Parameter {Name = redirectURI.Item1, Value = redirectURI.Item2, Type = type},
                new Parameter {Name = theScope.Item1, Value = theScope.Item2, Type = type},
                new Parameter {Name = theState.Item1, Value = theState.Item2, Type = type}
            };
            paramList.ForEach(p => request.AddParameter(p));
            // reference: https://github.com/justintv/Twitch-API#api-versions-and-mime-types
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _cookies = _cookies ?? new List<RestResponseCookie>();
                response.Cookies.ToList().ForEach(c => _cookies.Add(c));
            }
            else
            {
                handleException(response);
            }
        }
        public Channels GetChannel(string searchTerm)
        {
            var client = new RestClient(@"https://api.twitch.tv/kraken");
            // reference: https://github.com/justintv/Twitch-API/blob/master/v3_resources/search.md#get-searchchannels
            // reference: http://restsharp.org/
            var request = new RestRequest(String.Format(@"search/channels?q={0}", searchTerm));
            _cookies.ToList().ForEach(c => request.AddCookie(c.Name, c.Value));
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Channels>(response.Content);
            }
            handleException(response);
            return null;
        }
        private void handleException(IRestResponse response)
        {
            throw new HttpRequestException(String.Format("Exception '{0}' with status code '{1}' occurred.",
                response.Content, Enum.GetName(typeof(HttpStatusCode), response.StatusCode)));
        }
    }

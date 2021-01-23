    class MessageHandlerApiExplorer : IApiExplorer {
        private readonly ApiExplorer _proxy;
        public MessageHandlerApiExplorer() {
            _proxy = new ApiExplorer(GlobalConfiguration.Configuration);
            _descriptions = new Lazy<Collection<ApiDescription>>(GetDescriptions, true);
        }
        private readonly Lazy<Collection<ApiDescription>> _descriptions;
        private Collection<ApiDescription> GetDescriptions() {
            var desc = _proxy.ApiDescriptions;
            foreach (var handlerDesc in ReadDescriptionsFromHandlers()) {
                desc.Add(handlerDesc);
            }
            return desc;
        }
        public Collection<ApiDescription> ApiDescriptions => _descriptions.Value;
        private IEnumerable<ApiDescription> ReadDescriptionsFromHandlers() {
            foreach (var msg in Assembly.GetExecutingAssembly().GetTypes().Where(c => typeof(BaseMessage).IsAssignableFrom(c))) {
                var urlAttr = msg.GetCustomAttribute<MessageAttribute>();
                var respondsWith = msg.GetCustomAttribute<RespondsWithAttribute>();
                if (urlAttr != null && respondsWith != null) {
                    var desc = new ApiDescription() {
                        HttpMethod = HttpMethod.Get, // grab it from some attribute
                        RelativePath = urlAttr.Url,
                        Documentation = urlAttr.Description,
                        ActionDescriptor = new DummyActionDescriptor(msg, respondsWith.Type)
                    };                    
                   
                    var response = new ResponseDescription() {
                        DeclaredType = respondsWith.Type,
                        ResponseType = respondsWith.Type,
                        Documentation = "This is some response documentation you grabbed from some other attribute"
                    };                    
                    desc.GetType().GetProperty(nameof(desc.ResponseDescription)).GetSetMethod(true).Invoke(desc, new object[] {response});
                    yield return desc;
                }
            }
        }
    }

    /// <summary>
    /// Reprensets xml help block converter interface.
    /// </summary>
    public class HelpBlockRenderer : IHelpBlockRenderer
    {
        /// <summary>
        /// Stores regex to parse <c>See</c> tag.
        /// </summary>
        private static readonly Regex regexSeeTag = new Regex("<( *)see( +)cref=\"(?<prefix>[^\"]):(?<member>[^\"]+)\"( *)/>",
            RegexOptions.IgnoreCase);
        /// <summary>
        /// Stores the pair tag coversion dictionary.
        /// </summary>
        private static readonly Dictionary<string, string> pairedTagConvertsion = new Dictionary<string, string>()
        {
            { "para", "p" },
            { "c", "b" }
        };
        /// <summary>
        /// Stores configuration.
        /// </summary>
        private HttpConfiguration config;
        /// <summary>
        /// Initializes a new instance of the <see cref="HelpBlockRenderer"/> class. 
        /// </summary>
        /// <param name="config">The configuration.</param>
        public HelpBlockRenderer(HttpConfiguration config)
        {
            this.config = config;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="HelpBlockRenderer"/> class. 
        /// </summary>
        public HelpBlockRenderer()
            : this(GlobalConfiguration.Configuration)
        {
        }
        /// <summary>
        /// Renders specified xml help block to valid html content.
        /// </summary>
        /// <param name="helpBlock">The help block.</param>
        /// <param name="urlHelper">The url helper for link building.</param>
        /// <returns>The html content.</returns>
        public HtmlString RenderHelpBlock(string helpBlock, UrlHelper urlHelper)
        {
            if (string.IsNullOrEmpty(helpBlock))
            {
                return new HtmlString(string.Empty);
            }
            string result = helpBlock;
            result = this.RenderSeeTag(result, urlHelper);
            result = this.RenderPairedTags(result);
            return new HtmlString(result);
        }
        /// <summary>
        /// Process <c>See</c> tag.
        /// </summary>
        /// <param name="helpBlock">Hte original help block string.</param>
        /// <param name="urlHelper">The url helper for link building.</param>
        /// <returns>The html content.</returns>
        private string RenderSeeTag(string helpBlock, UrlHelper urlHelper)
        {
            string result = helpBlock;
            Match match = null;
            while ((match = HelpBlockRenderer.regexSeeTag.Match(result)).Success)
            {
                var originalValues = match.Value;
                var prefix = match.Groups["prefix"].Value;
                var anchorText = string.Empty;
                var link = string.Empty;
                switch (prefix)
                {
                    case "T":
                        {
                            // if See tag has reference to type, then get value from member regex group.
                            var modelType = match.Groups["member"].Value;
                            anchorText = modelType.Substring(modelType.LastIndexOf(".") + 1);
                            link = urlHelper.Action("ResourceModel", "Help",
                                new
                                {
                                    modelName = anchorText,
                                    area = "ApiHelpPage"
                                });
                            break;
                        }
                    case "M":
                        {
                            // Check that specified type member is API member.
                            var apiDescriptor = this.GetApiDescriptor(match.Groups["member"].Value);
                            if (apiDescriptor != null)
                            {
                                anchorText = apiDescriptor.ActionDescriptor.ActionName;
                                link = urlHelper.Action("Api", "Help",
                                    new
                                    {
                                        apiId = ApiDescriptionExtensions.GetFriendlyId(apiDescriptor),
                                        area = "ApiHelpPage"
                                    });
                            }
                            else
                            {
                                // Web API Help can generate help only for whole API model,
                                // So, in case if See tag contains link to model member, replace link with link to model class.
                                var modelType = match.Groups["member"].Value.Substring(0, match.Groups["member"].Value.LastIndexOf("."));
                                anchorText = modelType.Substring(modelType.LastIndexOf(".") + 1);
                                link = urlHelper.Action("ResourceModel", "Help",
                                    new
                                    {
                                        modelName = anchorText,
                                        area = "ApiHelpPage"
                                    });
                            }
                            break;
                        }
                    default:
                        {
                            anchorText = match.Groups["member"].Value;
                            // By default link will be rendered with empty anrchor.
                            link = "#";
                            break;
                        }
                }
                // Build the anchor.
                var anchor = string.Format("<a href=\"{0}\">{1}</a>", link, anchorText);
                result = result.Replace(originalValues, anchor);
            }
            return result;
        }
        /// <summary>
        /// Converts original help paired tags to html tags.
        /// </summary>
        /// <param name="helpBlock">The help block.</param>
        /// <returns>The html content.</returns>
        private string RenderPairedTags(string helpBlock)
        {
            var result = helpBlock;
            foreach (var key in HelpBlockRenderer.pairedTagConvertsion.Keys)
            {
                Regex beginTagRegex = new Regex(string.Format("<{0}>", key), RegexOptions.IgnoreCase);
                Regex endTagRegex = new Regex(string.Format("</{0}>", key), RegexOptions.IgnoreCase);
                result = beginTagRegex.Replace(result, string.Format("<{0}>", HelpBlockRenderer.pairedTagConvertsion[key]));
                result = endTagRegex.Replace(result, string.Format("</{0}>", HelpBlockRenderer.pairedTagConvertsion[key]));
            }
            return result;
        }
        /// <summary>
        /// Gets the api descriptor by specified member name.
        /// </summary>
        /// <param name="member">The member fullname.</param>
        /// <returns>The api descriptor.</returns>
        private ApiDescription GetApiDescriptor(string member)
        {
            Regex controllerActionRegex = new Regex("[a-zA-Z0-9\\.]+\\.(?<controller>[a-zA-Z0-9]+)Controller\\.(?<action>[a-zA-Z0-9]+)\\(.*\\)");
            var match = controllerActionRegex.Match(member);
            if (match.Success)
            {
                var controller = match.Groups["controller"].Value;
                var action = match.Groups["action"].Value;
                var descriptions = this.config.Services.GetApiExplorer().ApiDescriptions;
                return descriptions.FirstOrDefault(x => x.ActionDescriptor.ActionName.Equals(action) &&
                    x.ActionDescriptor.ControllerDescriptor.ControllerName == controller);
            }
            return null;
        }
    }

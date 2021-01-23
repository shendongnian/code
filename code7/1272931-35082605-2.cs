    /// <summary>
    /// Represents html help content extension class.
    /// Contains methods to convert Xml help blocks to html string.
    /// </summary>
    public static class HtmlHelpContentExtensions
    {
        /// <summary>
        /// Converts help block in xml format to html string with proper tags, links and etc.
        /// </summary>
        /// <param name="helpBlock">The help block content.</param>
        /// <param name="urlHelper">The url helper for link building.</param>
        /// <returns>The resulting html string.</returns>
        public static HtmlString ToHelpContent(this string helpBlock, UrlHelper urlHelper)
        {
            // Initialize your rendrer here or take it from IoC
            return renderer.RenderHelpBlock(helpBlock, urlHelper);
        }
    }

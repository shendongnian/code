         internal NavPanelNode GenerateNode(IWebContext webContext, ...)
         {
                return new NavPanelNode
                {
                    Title = _title,
                    Url = _url,
                    Children = _childNodeBuilder == null ? Enumerable.Empty<NavPanelNode>() : _childNodeBuilder.GenerateNodeHierachy(webContext, userContext),
                    IsSelected = _urlMatchPattern.Any(pattern => webContext.MatchesPath(pattern)),
                    IconUrl = _iconUrl
                };
       }

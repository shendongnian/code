            var homeNode = Model.Content.AncestorOrSelf("[HomeNodeDocumentType]");
        }
        @foreach (var node in homeNode.Children.Where(x => x.IsVisible))
        {
            <li>
                <a href="@node.Url">@node.AsDynamic().yourFieldForTheTitle</a>
            </li>
        }

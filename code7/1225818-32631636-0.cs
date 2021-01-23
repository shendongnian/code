    for (r.MoveToContent(); r.NodeType != XmlNodeType.EndElement; r.MoveToContent())
                {
                    if (r.NamespaceURI != DbmlNamespace)
                        r.Skip();
                    else
                        throw UnexpectedItemError(r);
                }

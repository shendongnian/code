    XNamespace dcNamespace = "http://purl.org/dc/elements/1.1/";
    foreach (XElement rss in elements)
    {
        Lista.Add(
            new Model
            {
                Titulo = rss.Element("title").Value,
                DataPublicacao = rss.Element("pubDate").Value,
                Descricao = rss.Element("description").Value,
                Autor = rss.Element(dcNamespace + "creator").Value,
                Link = rss.Element("link").Value
            }
        );
    }

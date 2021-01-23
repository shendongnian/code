    private void button2_Click(object sender, EventArgs e)
            {
                XDocument xdoc = XDocument.Load(FILENAME);
                XElement playlist = (XElement)xdoc.FirstNode;
                XNamespace ns = playlist.Name.Namespace;
                XNamespace nx = ("http://www.videolan.org/vlc/playlist/ns/0/");
                XElement extension = playlist.Elements().Where(x => x.Name.LocalName == "extension").FirstOrDefault();
                XNamespace nsExtension = extension.Name.Namespace;
                XElement node = extension.Elements().Where(x => x.Name.LocalName == "node").FirstOrDefault();
                var nodes = node.Elements().Where(x => x.Name.LocalName == "node").Select(y => new {
                    title = y.Attribute("title").Value,
                    ids = y.Elements().Select(x => int.Parse(x.Attribute("tid").Value)).ToList()
                }).ToList();
                
            }

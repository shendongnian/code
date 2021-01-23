    /// <summary>
        /// Gets all plain text from an .odt file
        /// </summary>
        /// <param name="path">
        /// the physical path of the file
        /// </param>
        /// <returns>a string with all text content</returns>
        public String GetTextFromOdt(String path)
        {
            var sb = new StringBuilder();
            using (var doc = new TextDocument())
            {
                doc.Load(path);
                //The header and footer are in the DocumentStyles part. Grab the XML of this part
                XElement stylesPart = XElement.Parse(doc.DocumentStyles.Styles.OuterXml);
                //Take all headers and footers text, concatenated with return carriage
                string stylesText = string.Join("\r\n", stylesPart.Descendants().Where(x => x.Name.LocalName == "header" || x.Name.LocalName == "footer").Select(y => y.Value));
                //Main content
                var mainPart = doc.Content.Cast<IContent>();
                var mainText = String.Join("\r\n", mainPart.Select(x => x.Node.InnerText));
                //Append both text variables
                sb.Append(stylesText + "\r\n");
                sb.Append(mainText);
            }
            return sb.ToString();
        }
 

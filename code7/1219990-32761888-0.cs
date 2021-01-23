    class CustomXmlDeserializer : RestSharp.Deserializers.XmlDeserializer {
        public override T Deserialize<T>(IRestResponse response) {
            //string pattern = @"&#x((10?|[2-F])FFF[EF]|FDD[0-9A-F]|7F|8[0-46-9A-F]9[0-9A-F])"; // XML 1.0
            string pattern = @"#x((10?|[2-F])FFF[EF]|FDD[0-9A-F]|[19][0-9A-F]|7F|8[0-46-9A-F]|0?[1-8BCEF])"; // XML 1.1
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            if (regex.IsMatch(response.Content)) {
                response.Content = regex.Replace(response.Content, String.Empty);
            }
            response.Content = response.Content.Replace("&;", string.Empty);
            return base.Deserialize<T>(response);
        }
	}

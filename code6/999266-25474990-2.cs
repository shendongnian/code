        public static string ExtractVkResponseIds(string vkResponseJson)
        {
            vkResponse[] vkResponses = JsonConvert.DeserializeObject<vkResponse[]>(vkResponseJson);
            if (vkResponses == null)
                throw new JsonException();
            StringBuilder sb = new StringBuilder();
            // Format the ids as a comma separated string.
            foreach (var response in vkResponses)
            {
                if (sb.Length > 0)
                    sb.Append(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator);
                sb.Append(response.Id.ToString());
            }
            return sb.ToString();
        }

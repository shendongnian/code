            try
            {
                // Fill in the returnSearch
                // Convert to JObject and return
                var settings = new JsonSerializerSettings
                {
                    Converters = new[] { new EncodingValidatingStringConverter(Encoding.GetEncoding(Encoding.UTF8.CodePage, new EncoderExceptionFallback(), new DecoderExceptionFallback())) },
                };
                return JObject.FromObject(returnSearch, JsonSerializer.CreateDefault(settings));
            }
            catch (EncoderFallbackException ex)
            {
                // Log the encoding error for debugging:
                ValuesController.Log("Encoding exception:\n" + ex.ToString());
                // You could log the search parameters or entire search_items list as well if desired.
                // Return whatever seems most advisable, e.g. replacing the bad character with a fallback if preferred.
                var settings = new JsonSerializerSettings
                {
                    Converters = new[] { new EncodingValidatingStringConverter(Encoding.GetEncoding(Encoding.UTF8.CodePage, new EncoderReplacementFallback("?"), new DecoderExceptionFallback())) },
                };
                return JObject.FromObject(returnSearch, JsonSerializer.CreateDefault(settings));
            }
            catch (Exception ex)
            {
                returnSearch.status = "Failed";
                returnSearch.search_items = null;
                ValuesController.Log("Error in Search: " + ex.Message);
                var settings = new JsonSerializerSettings
                {
                    Converters = new[] { new EncodingValidatingStringConverter(Encoding.GetEncoding(Encoding.UTF8.CodePage, new EncoderReplacementFallback("?"), new DecoderExceptionFallback())) },
                };
                return JObject.FromObject(returnSearch, JsonSerializer.CreateDefault(settings));
            }

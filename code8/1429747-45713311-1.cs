    public GetCategoryFeaturesResponseType GetCategoryFeatures(int categoryId)
            {
                var apiCall = new GetCategoryFeaturesCall(ApiContext)
                {
                    CategoryID = categoryId.ToString()
                };
                
                try
                {
                    apiCall.GetCategoryFeatures();
                }
                catch (Exception e)
                {
                    return null;
                }
    
                var response = apiCall.SoapResponse;
    
                if (response == null)
                    return null;
    
                response = TrimXml(response, "<GetCategoryFeaturesResponse xmlns=\"urn:ebay:apis:eBLBaseComponents\">",
                    "</GetCategoryFeaturesResponse>");
    
                var responseStream = Helpers.Serialization.CreateStream(response);
    
                var rootAttribute = new XmlRootAttribute()
                {
                    ElementName = "GetCategoryFeaturesResponse",
                    Namespace = "urn:ebay:apis:eBLBaseComponents",
                    IsNullable = true
                };
    
    
                GetCategoryFeaturesResponseType categoryFeatures;
                try
                {
                    categoryFeatures =
                        Helpers.Serialization.SerializeToModel<GetCategoryFeaturesResponseType>(responseStream,
                            rootAttribute);
                }
                catch (Exception e)
                {
                    return null;
                }
    
                return categoryFeatures;
            }
    
    
    private static string TrimXml(string origin, string begin, string end)
            {
                var startIndex = origin.IndexOf(begin, StringComparison.Ordinal);
                var endLength = origin.IndexOf(end, StringComparison.Ordinal);
                endLength = endLength - startIndex + end.Length;
    
                return origin.Substring(startIndex, endLength);
            }

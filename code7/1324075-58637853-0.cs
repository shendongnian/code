    `        private static string GetSignatureBaseString(string strUrl, string TimeStamp,
                string Nonce, string strConsumer, string strOauthToken, SortedDictionary<string, string> data)
            {
                //1.Convert the HTTP Method to uppercase and set the output string equal to this value.
                string Signature_Base_String = "POST";
                Signature_Base_String = Signature_Base_String.ToUpper();
    
                //2.Append the ‘&’ character to the output string.
                Signature_Base_String = Signature_Base_String + "&";
    
                //3.Percent encode the URL and append it to the output string.
                string PercentEncodedURL = Uri.EscapeDataString(strUrl);
                Signature_Base_String = Signature_Base_String + PercentEncodedURL;
    
                //4.Append the ‘&’ character to the output string.
                Signature_Base_String = Signature_Base_String + "&";
    
                //5.append OAuth parameter string to the output string.
                var parameters = new SortedDictionary<string, string>
                {
                    {"oauth_consumer_key", strConsumer},
                    { "oauth_token", strOauthToken },
                    {"oauth_signature_method", "HMAC-SHA1"},
                    {"oauth_timestamp", TimeStamp},
                    {"oauth_nonce", Nonce},
                    {"oauth_version", "1.0"}
                };
    
                //6.append parameter string to the output string.
                foreach (KeyValuePair<string, string> elt in data)
                {
                    parameters.Add(elt.Key, elt.Value);
                }
    
                bool first = true;
                foreach (KeyValuePair<string, string> elt in parameters)
                {
                    if (first)
                    {
                        Signature_Base_String = Signature_Base_String + Uri.EscapeDataString(elt.Key + "=" + elt.Value);
                        first = false;
                    }
                    else
                    {
                        Signature_Base_String = Signature_Base_String + Uri.EscapeDataString("&" + elt.Key + "=" + elt.Value);
                    }
                }
    
                return Signature_Base_String;
            }
`

          using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                        if (response.StatusCode == HttpStatusCode.OK && response.StatusDescription.ToUpper() == "OK" && !string.IsNullOrEmpty(responseContent))
                        {
                            objFSLstGetAgent = JsonConvert.DeserializeObject<YourObjectClass>(responseContent);
                        }
                    }

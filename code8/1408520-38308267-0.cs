     #region Serialize
            /// <summary>
            /// Serializes the specified model.
            /// </summary>
            /// <param name="model">The model that you wish to serialize.</param>
            /// <param name="useDataContract">if set to <c>true</c> use the DataContractSerializer.</param>
            /// <returns>System.String.</returns>
            public static string Serialize(object model, bool useDataContract = false)
            {
                if (useDataContract)
                {
                    string result = string.Empty;
                    DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings { SerializeReadOnlyTypes = true, RootName = "root", MaxItemsInObjectGraph = 1000 };
                    DataContractJsonSerializer js = new DataContractJsonSerializer(model.GetType(), settings);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        js.WriteObject(ms, model);
                        ms.Position = 0;
                        using (StreamReader sr = new StreamReader(ms))
                        {
                            result = sr.ReadToEnd();
                        }
                    }
                    return result;
                }
                else
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(model);
                }
            }
            #endregion

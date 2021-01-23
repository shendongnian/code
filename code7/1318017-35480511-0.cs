    var x = JObject.Parse(json);
                var xx = x.Descendants().ToList().Where(d => d.Path.ToLower().EndsWith("$ref"));
                foreach (var item in xx)
                {
                    if (!item.HasValues)
                        continue;
                    string str = item.First.ToString().TrimStart(new char[] { '#' }).TrimStart(new char[] { '/' });
                    var split = str.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                JToken token = x;
                for (int i = 0;i<split.Length; i++)
                {
                    token = token[split[i]];
                }
                item.Parent.Replace(token);
            }
            
            var doc = JsonConvert.DeserializeObject<RootDoc>(x.ToString(), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
                {
                    // Handle all errors
                    args.ErrorContext.Handled = true;
                }
            });
            Assert.IsNotNull(doc);
            Assert.IsNotNull(doc.Items);
            Assert.IsTrue(doc.Items.Count == 2);
            Assert.IsTrue(doc.Items[0].Name == "X-requestId");
            Assert.IsTrue(doc.Items[1].Name == "user");

                // Decode the encoded string.
                StringWriter myWriter = new StringWriter();
                HttpUtility.HtmlDecode(encodedHtmlString, myWriter);
                string DecodedHtmlString = myWriter.ToString();
                //find and replace each img src with byte string
                 HtmlDocument document = new HtmlDocument();
                 document.LoadHtml(DecodedHtmlString);
                 document.DocumentNode.Descendants("img")
                  .Where(e =>
                {
                    string src = e.GetAttributeValue("src", null) ?? "";
                    return !string.IsNullOrEmpty(src);//&& src.StartsWith("data:image");
                })
                .ToList()
                            .ForEach(x =>
                            {
                                string currentSrcValue = x.GetAttributeValue("src", null);                                
                                string filePath = Path.GetDirectoryName(currentSrcValue) + "\\";
                                string filename = Path.GetFileName(currentSrcValue);
                                string contenttype = "image/" + Path.GetExtension(filename).Replace(".", "");
                                FileStream fs = new FileStream(filePath + filename, FileMode.Open, FileAccess.Read);
                                BinaryReader br = new BinaryReader(fs);
                                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                                br.Close();
                                fs.Close();
                                x.SetAttributeValue("src", "data:" + contenttype + ";base64," + Convert.ToBase64String(bytes));                                
                            });
                string result = document.DocumentNode.OuterHtml;
                //Encode HTML string
                string myEncodedString = HttpUtility.HtmlEncode(result);
                Emailmodel.DtEmailFields.Rows[0]["Body"] = myEncodedString;

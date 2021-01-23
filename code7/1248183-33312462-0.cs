    string[] split = Regex.Split(text, "</ss>");
                text = "";
                foreach (string s in split)
                {
                    Regex regex = new Regex(@"(?<=\btype="")[^""]*");
                    string smily = regex.Match(s).Value;
                    string result = Regex.Replace(s, @"<(.|\n)*?>", string.Empty);
                    writer.WriteEncodedText(result);
                    if (smily != string.Empty)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Src, "./Emoticons/" + smily + ".png");
                        writer.RenderBeginTag(HtmlTextWriterTag.Img);
                    }
                }

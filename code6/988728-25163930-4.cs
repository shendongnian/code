    public virtual string RenderEmptyLinkInEditing<T>(T model, Expression<Func<T, object>> field, object attributes = null, bool isEditable = false, string contents = null)
            {
                NameValueCollection attrs = null;
    
                if (attributes is NameValueCollection)
                {
                    attrs = attributes as NameValueCollection;
                }
                else
                {
                    attrs = Utilities.GetPropertiesCollection(attributes, true);
                    
                }
    
                var sb = new StringBuilder();
                var writer = new StringWriter(sb);
    
                RenderingResult result = null;
                if (IsInEditingMode && isEditable)
                {
    
                    if (contents.IsNotNullOrEmpty())
                    {
                        attrs.Add("haschildren", "true");
                    }
    
                    result = MakeEditable(
                        field,
                        null, 
                        model,  
                        attrs,
                        _context, SitecoreContext.Database, writer);
    
                  //  if (contents.IsNotNullOrEmpty())
                  //  {
                  //      sb.Append(contents);
                  //  }
                }
                else
                {
                    result = BeginRenderLink(
                            field.Compile().Invoke(model) as Fields.Link, attrs, contents, writer
                        );
                }
    
                result.Dispose();
                writer.Flush();
                writer.Close();
                return sb.ToString();
    
            }

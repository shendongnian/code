      try
        {
        Rchtxt_Editor1.Document = ImportHtml(string.Concat("<P>string1</P>","<P>string2</P>"));
        }
         catch(Exception ex)
        {
        throw ex;
        }
        
     public RadDocument ImportHtml(string content)
    {
     try
        {
         XamlFormatProvider provider = new XamlFormatProvider();
                    return provider.Import(content);
          }
         
        catch(Exception ex)
        {
        throw ex;
        }
    }

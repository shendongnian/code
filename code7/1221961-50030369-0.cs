    public class MyXamlFormatter : ITextFormatter
    {
        public string GetText( System.Windows.Documents.FlowDocument document )
        {
          TextRange tr = new TextRange( document.ContentStart, document.ContentEnd );
          using( MemoryStream ms = new MemoryStream() )
          {
            tr.Save( ms, DataFormats.Xaml );
            return Encoding.UTF8.GetString(ms.ToArray());
          }
        }
    
        public void SetText( System.Windows.Documents.FlowDocument document, string text )
        {
          try
          {
            if( String.IsNullOrEmpty( text ) )
            {
              document.Blocks.Clear();
            }
            else
            {
              TextRange tr = new TextRange( document.ContentStart, document.ContentEnd );
              using( MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(text)))
              {
                tr.Load( ms, DataFormats.Xaml );
              }
            }
          }
          catch
          {
            throw new InvalidDataException( "Data provided is not in the correct Xaml format." );
          }
        }
    }

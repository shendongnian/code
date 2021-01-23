    public interface ITextFieldParserService
    {
       string ReadLine();
    }
    public class DefaultTextFieldParserService : ITextFieldParserService
    {
       private TextFieldParser parser;
       public ITextFieldParserService Setup(string path)
       {
           parser = new TextFieldParser(path);
       }
       //you'd want some teardown method to dispose of TextFieldParser, or make
       //the service IDisposable probably
    }
    public class FileParser : IFileParser
    {
       public FileParser(ITextFieldParserService textParserService)
       {
       }
       ...
       public string ParseFirstRowForDelimiters(string path)
       {
           var parser = textParserService.Setup(path)        
            string line = parser.ReadLine();
            if(lineContains("'"))
            {
                return "'";
            }
            if(lineContains("\"")
            {
                return "\"";
            }
            return "";         
       }

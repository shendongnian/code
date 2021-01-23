     public class ValidateResponse
        {
            public List<HitParsingResult> hitParsingResult { get; set; }
            public List<ParserMessage2> parserMessage { get; set; }
    
            public class ParserMessage
            {
                public string messageType { get; set; }
                public string description { get; set; }
                public string messageCode { get; set; }
                public string parameter { get; set; }
            }
    
            public class HitParsingResult
            {
                public bool valid { get; set; }
                public List<ParserMessage> parserMessage { get; set; }
                public string hit { get; set; }
            }
    
            public class ParserMessage2
            {
                public string messageType { get; set; }
                public string description { get; set; }
            }
        }

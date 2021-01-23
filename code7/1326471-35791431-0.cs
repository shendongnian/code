    public class JsonNetFormatterDecide : MediaTypeFormatter
    {   
        //......
        public override bool CanReadType(Type type)
        {
            return false; //this causes the // project to use the second formatter in the config file ie,JsonMediaTypeFormatter  or the //default Json Formatter
        }
    } 

    public class ValueObj{
    
        private string[] _postfixList;
    
        public string[] PostfixList{ get{
            if(_postFixList == null){
                _postFixList = postfix("postfixList")
            }
            return _postfixList
        }}
    }

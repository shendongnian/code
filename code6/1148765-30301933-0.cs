    public class Converter
    { 
        public ScoreConverter scoreConverter { get; set; }
        public void modifyScore(string convertTo){
          
          if(convertTo.Equals("decimal"){    
               scoreConverter = new DecimalScoreConverter();
          }
          else{
               scoreConverter = new IntegerScoreConverter();
          }
          scoreConverter.determineScore();
    }

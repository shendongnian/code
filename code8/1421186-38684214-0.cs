    //pseudo code
    void main(string[] args){
        Regex regex = new Regex("^1(2|3)4$");
        RegexProcessor processor = new RegexProcessor(regex);
        bool step1 = processor.Input('1'); //return true and iterates to next step
        char[] validInput = processor.GetValidInput(); //returns new char[]{'2','3'}
        
        bool step2 = processor.Input('4'); //return false because on step2 (2|3) is accepted
    }

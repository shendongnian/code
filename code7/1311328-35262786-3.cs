    public class SomeObject {
        iLevel myLevel = new iLevel();
        int x = -1;
    
        if(myLevel is Level1) {
            x = (myLevel is Level1).GetANumber();
        }
    }

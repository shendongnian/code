    public class SomeObject {
        iLevel myLevel = new iLevel();
        int x = -1;
    
        if(myLevel is Level1) {
            int x = (myLevel is Level1).GetANumber();
        }
    }

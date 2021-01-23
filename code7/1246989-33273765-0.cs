public class Computer {
    private int coreCount;
    public int CoreCount {
        get {return coreCount;}
        set {
            if (value > 0)
                coreCount = value;
        }
    }
}

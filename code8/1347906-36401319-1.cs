    public interface IPondBird
    {
        string Says { get; set; }
        object NativeObject { get; }
    }
    public class Duck
    {
        public string Says { get; set; }
        public int GetNumberOfQuacksPerMinute()
        {
            return 42;
        }
        public object NativeObject { get { return this; } }
    }
    IPondBird myInterface = Impromptu.ActLike(thing);   
    var duck = (Duck)myInterface.NativeObject;

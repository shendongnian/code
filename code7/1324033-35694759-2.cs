        FileCode FileCode { get; }
    }
    public abstract class Thing : IThing
    {
        protected Thing(FileCode fileCode)
        {
            FileCode = fileCode;
        }
        public FileCode FileCode { get; private set; }
    }
    public class ThingFoo : Thing
    {
        public ThingFoo(FileCode fileCode) : base(fileCode) { }
    }
    public class ThingBar : Thing
    {
        public ThingBar(FileCode fileCode) : base(fileCode) { }
    }
    public interface IOtherThing
    {
        FileCode FileCode { get; }
    }
    public abstract class OtherThing : IOtherThing
    {
        protected OtherThing(FileCode fileCode)
        {
            FileCode = fileCode;
        }
        public FileCode FileCode { get; private set; }
    }
    public class OtherThingFoo : OtherThing
    {
        public OtherThingFoo(FileCode fileCode) : base(fileCode) { }
    }
    public class OtherThingBar : OtherThing
    {
        public OtherThingBar(FileCode fileCode) : base(fileCode) { }
    }
    public class OtherThingWrapper
    {
        public OtherThingWrapper(IOtherThing otherThing)
        {
            OtherThing = otherThing;
        }
        public IOtherThing OtherThing { get; private set; }
    }
    public class FileProcessor
    {
        public FileProcessor(IThing thing, OtherThingWrapper otherThingWrapper)
        {
            Thing = thing;
            OtherThingWrapper = otherThingWrapper;
        }
        public IThing Thing { get; private set; }
        public OtherThingWrapper OtherThingWrapper { get; private set; }
    }

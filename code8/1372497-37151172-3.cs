    public class Inverse : Command
    {
        public override void Process(List<string> output)
        {
            var inverseContent = this.Content; //todo: process
            output.Add(inverseContent);
        }
    }
    public class Reverse : Command
    {
        public override void Process(List<string> output)
        {
            var reverseContent = this.Content; //todo: process
            output.Add(reverseContent);
        }
    }

    public class myArguments : IEquatable<List<string>>
    {
        public List<string> argNames { get; set; }
        public bool Equals(List<string> other)
        {
            if (object.ReferenceEquals(argNames, other))
                return true;
            if (object.ReferenceEquals(argNames, null) || object.ReferenceEquals(other, null))
                return false;
            return argNames.SequenceEqual(other);
        }
    }

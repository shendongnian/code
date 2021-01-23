    public override int GetHashCode() {
        return Time.GetHashCode();
    }
    public override bool Equals(obj other) {
        //skipping type check and null check for brevity
        return Time.Equals(other.Time);
    }

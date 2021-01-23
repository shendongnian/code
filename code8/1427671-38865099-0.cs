    public static bool operator ==(Thing self, Thing other)
    {
        return !ReferenceEquals(self, null) && !ReferenceEquals(other, null)  && self.Id == other.Id;
    }
    public static bool operator !=(Thing self, Thing other)
    {
        return !(self == other);
    }

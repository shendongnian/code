    public class Size
    {
        //Properties and stuff...
        public override Equals(object obj)
        {
            Size other = obj as Size;
            if (other != null)
                return other.Name == this.Name && other.Bytes == this.Bytes;
            return false;
        }
    }

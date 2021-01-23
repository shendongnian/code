    public class Fill
    {
        public string arret { get; set; }
        public string ligneSens { get; set; }
        public override bool Equals(object obj)
        {
            var other = obj as Fill;
            if(other == null)
                return false;
            return other.arret == arret && other.ligneSens == ligneSens;
        }
        public override int GetHashCode()
        {
            return arret.GetHashCode() ^
                   ligneSens.GetHashcode();
        }
    }

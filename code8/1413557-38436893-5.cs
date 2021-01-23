    internal class NamedObject {
        public NamedObject(string name) {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(name);
            if (name[0] != '{') {
                // eagerly add {} around the name
                _name = String.Format(CultureInfo.InvariantCulture, "{{{0}}}", _name);
            } else {
                _name = name;
            }
        }
        public override string ToString() {
            return _name;
        }
        string _name;
    }

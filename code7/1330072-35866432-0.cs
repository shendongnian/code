    struct Identifier {
        string name;
        string email;
        int nameHash;
        int emailHash;
        public Identifier(string name, string email) {
            this.name = name;
            nameHash = name.GetHashCode();
            this.email = email;
            emailHash = email.GetHashCode();
        }
        bool Equals(string name, string email) {
            return name.GetHashCode() == nameHash
                && email.GetHashCode() == emailHash
                && name.equals(this.name)
                && email.equals(this.email);
        }
    }

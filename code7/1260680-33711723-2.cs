    class Magazine
    {
        public readonly Type GunType;
        public Magazine (Type gunType)
        {
            this.GunType = gunType;
        }
    }
    class Gun
    {
        // Factory method
        public Magazine CreateMagazine()
        {
            return new Magazine(this.GetType());
        }
        public Magazine Reload(Magazine newMag)
        {
            // Test whether the magazine is compatible with the current gun.
            if (newMag.GunType != this.GetType()) {
                throw new ArgumentException();
            }
            // Your reload logic goes here ...
        }
    }

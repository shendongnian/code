    class Magazine
        public readonly Type GunType;
        public Magazine (Type gunType)
        {
            this.GunType = gunType;
        }
    }
    class Gun
    {
        // Factory method
        Magazine CreateMagazine()
        {
            return new Magazine(this.GetType());
        }
        public Magazine reload(Magazine newMag)
        {
            if (newMag.GunType != this.GetType()) {
                throw new ArgumentException();
            }
            ...
        }
    }

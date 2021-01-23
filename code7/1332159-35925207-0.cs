    public class Weapon
    {
        private string _name;
        private double _range;
        private double _damage;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public double Range
        {
            get
            {
                return _range;
            }
            set
            {
                if (value >= 0)
                    _range = value;
                else
                    throw new ArgumentException("Invalid Range");
            }
        }
        public double Damage
        {
            get
            {
                return _damage;
            }
            set
            {
                if (value >= 0)
                    _damage = value;
                else
                    throw new ArgumentException("Invalid Damage");
            }
        }
        public Weapon(string n, double d)
        {
            Name = n;
            Damage = d;
        }
        public Weapon(string n, double r, double d)
        {
            Name = n;
            Range = r;
            Damage = d;
        }
    }

    public class Crew : ICrew 
    {
        // Implement ICrew members
        public IMod Weapon { get; set; }
        public IMod Helm { get; set; }
        public IMod Armor { get; set; }
        public string Name { get; set; }
        public int BaseHealth { get; set; }
        public int BaseMana { get; set; }
        public int BaseStrength { get; set; }
        public int BaseDexterity { get; set; }
        public int BaseArmor { get; set; }
        public int TotalHealth
        {
            get { return CalculateHealth(); }
        }
        public int TotalMana
        {
            get { return CalculateMana(); }
        }
        public int TotalStrength
        {
            get { return CalculateStrength(); }
        }
        public int TotalDexterity
        {
            get { return CalculateDexterity(); }
        }
        public int TotalArmor
        {
            get { return CalculateArmor(); }
        }
        private int CalculateHealth()
        {
            int additionalHealth = 0;
            if (Weapon != null)
                additionalHealth += Weapon.HealthMod;
            if (Helm != null)
                additionalHealth += Helm.HealthMod;
            if (Armor != null)
                additionalHealth += Armor.HealthMod;
            return additionalHealth + BaseHealth;
        }
        private int CalculateMana()
        {
            int additionalMana = 0;
            if (Weapon != null)
                additionalMana += Weapon.ManaMod;
            if (Helm != null)
                additionalMana += Helm.ManaMod;
            if (Armor != null)
                additionalMana += Armor.ManaMod;
            return additionalMana + BaseMana;
        }
        private int CalculateStrength()
        {
            int additionalStrength = 0;
            if (Weapon != null)
                additionalStrength += Weapon.StrengthMod;
            if (Helm != null)
                additionalStrength += Helm.StrengthMod;
            if (Armor != null)
                additionalStrength += Armor.StrengthMod;
            return additionalStrength + BaseStrength;
        }
        private int CalculateDexterity()
        {
            int additionalDexterity = 0;
            if (Weapon != null)
                additionalDexterity += Weapon.DexterityMod;
            if (Helm != null)
                additionalDexterity += Helm.DexterityMod;
            if (Armor != null)
                additionalDexterity += Armor.DexterityMod;
            return additionalDexterity + BaseDexterity;
        } 
        private int CalculateArmor()
        {
            int additionalArmor = 0;
            if (Weapon != null)
                additionalArmor += Weapon.ArmorMod;
            if (Helm != null)
                additionalArmor += Helm.ArmorMod;
            if (Armor != null)
                additionalArmor += Armor.ArmorMod;
            return additionalArmor + BaseArmor;
        }       
    }

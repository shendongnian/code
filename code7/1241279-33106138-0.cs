    public class BaseCharacterClass 
    {
        public BaseCharacterStats BaseStats { get; set; }
        public BaseCharacterClass(int startingHealth) 
        {
            BaseStats = new BaseCharacterStats {Health = new CharacterHealth(startingHealth)}; //Testing purposes
            BaseStats.ChanceForCriticalStrike = new Random().Next(0,BaseStats.CriticalStrikeCounter);
        }
        
        public bool CanDoExtraDamage() 
        {
            if (BaseStats.ChanceForCriticalStrike*BaseStats.Luck < 50) return false;
            BaseStats.CriticalStrikeCounter--;
            BaseStats.ChanceForCriticalStrike = new Random().Next(0, BaseStats.CriticalStrikeCounter);
            BaseStats.AjustCriticalStrikeChances(); 
            return true;
        }
    }

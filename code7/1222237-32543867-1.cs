    public class Equipment { }
    public class Sword : Equipment { }
    public class GreatSword : Sword { }
    public class Character
    {
        public virtual Boolean Wield(Equipment e)
        {
            // do wield logic...
            return true;
        }
    }
    public class Paige : Character
    {
        public override Boolean Wield(Equipment e)
        {
            if (e is GreatSword)
            {
                return false;
            }
            return base.Wield(e);
        }
    }

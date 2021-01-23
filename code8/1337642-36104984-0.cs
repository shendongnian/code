    public interface IAttackable
    {
        void OnAttacked(IAttacker attacker);
    }
    public interface IAttacker
    {
        void OnAttack(IAttackable opponet);
    }
    public class Hero : IAttacker, IAttackable
    {
        public void OnAttack(IAttackable opponet)
        {
        }
        public void OnAttacked(IAttacker attacker)
        {
        }
    }
    public class Monster : IAttacker, IAttackable
    {
        public void OnAttack(IAttackable opponet)
        {
        }
        public void OnAttacked(IAttacker attacker)
        {
        }
    }

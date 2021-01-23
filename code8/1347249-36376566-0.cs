    public interface IBreathing
    {
        void Breathe();
    }
    //because every human breathe
    public abstract class Human : IBreathing
    {
        abstract void Breathe();
    }
    public interface IVillain
    {
        void FightHumanity();
    }
    public interface IHero
    {
        void SaveHumanity();
    }
    //not every human is a villain
    public class HumanVillain : Human, IVillain
    {
        void Breathe() {}
        void FightHumanity() {}
    }
    
    //but not every is a hero either
    public class HumanHero : Human, IHero
    {
        void Breathe() {}
        void SaveHumanity() {}
    }

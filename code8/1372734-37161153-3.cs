    using AnimalManagers;
    using System.ComponentModel.Composition;
    namespace AnimalModels
    {
        [Export(typeof(AnimalAggressiveBase<Cat>))]
        public class Dog : AnimalAggressiveBase<Cat>
        {
            public override string BarkAtEnemy(Cat enemy)
            {
                return enemy.Name;
            }
        }
    }

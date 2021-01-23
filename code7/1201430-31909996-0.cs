		public abstract class Animal : IComparable
        {
            public abstract SortOrder SortOrder { get; }
            public virtual int CompareTo(object obj)
            {
                Animal rightValue = (Animal)obj;
                return this.SortOrder < rightValue.SortOrder ? -1
                    : this.SortOrder > rightValue.SortOrder ? 1 : 0;
            }
        }
        public class Wolf : Animal
        {
            public override SortOrder SortOrder { get { return SortOrder.Wolf; } }
            public int kills = 0; //Marked public for simple initialization
            public override int CompareTo(object obj)
            {
                if (obj is Wolf)
                {
                    Wolf rightValue = (Wolf)obj;
                    return this.kills < rightValue.kills ? -1
                        : this.kills > rightValue.kills ? 1 : 0;
                }
                else
                {
                    return base.CompareTo(obj);
                }
            }
        }
        public class Rabbit : Animal
        {
            public override SortOrder SortOrder { get { return SortOrder.Rabbit; } }
            public string name = "Funny Little Guy"; //Marked public for simple initialization
            public override int CompareTo(object obj)
            {
                if (obj is Rabbit)
                {
                    Rabbit rightValue = (Rabbit)obj;
                    return String.Compare(this.name, rightValue.name);
                }
                else
                {
                    return base.CompareTo(obj);
                }
            }
        }
        public class Eagle : Animal
        {
            public override SortOrder SortOrder { get { return SortOrder.Eagle; } }
            public byte eyeCount = 2; //Marked public for simple initialization
            public override int CompareTo(object obj)
            {
                if (obj is Eagle)
                {
                    Eagle rightValue = (Eagle)obj;
                    return this.eyeCount < rightValue.eyeCount ? -1
                        : this.eyeCount > rightValue.eyeCount ? 1 : 0;
                }
                else
                {
                    return base.CompareTo(obj);
                }
            }
        }

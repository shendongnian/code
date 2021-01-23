    public abstract class ProductComponentBase : IProductComponent
    {
        string name;
        protected ProductComponentBase(string name)
        {
            this.name = name;
        }
        #region IProductComponent Members
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public virtual IEnumerable<IProductComponent> ChildComponents
        {
            get
            {
                return Enumerable.Empty<IProductComponent>();
            }
        }
        public IEnumerable<IProductComponent> WalkAllComponents
        {
            get
            {
                yield return this;
                foreach (var child in ChildComponents)
                {
                    foreach (var subChild in child.WalkAllComponents)
                        yield return subChild;
                }
            }
        }
        public TProductComponent UniqueProductComponent<TProductComponent>() where TProductComponent : class, IProductComponent
        {
            TProductComponent foundComponent = null;
            foreach (var child in WalkAllComponents.OfType<TProductComponent>())
            {
                if (foundComponent == null)
                    foundComponent = child;
                else
                    throw new Exception("Duplicate products found of type " + typeof(TProductComponent).Name);
            }
            return foundComponent;
        }
        #endregion
    }
    public class Telephone : ProductComponentBase, ITelephone
    {
        IGps gps = new Gps();
        public Telephone()
            : base("telephone")
        {
        }
        #region ITelephone Members
        public IGps Gps
        {
            get
            {
                return gps;
            }
        }
        #endregion
        IEnumerable<IProductComponent> BaseChildComponents
        {
            get
            {
                return base.ChildComponents;
            }
        }
        public override IEnumerable<IProductComponent> ChildComponents
        {
            get
            {
                if (Gps != null)
                    yield return Gps;
                foreach (var child in BaseChildComponents)
                    yield return child;
            }
        }
    }
    public class Gps : ProductComponentBase, IGps
    {
        public Gps()
            : base("gps")
        {
        }
        #region IGps Members
        public double AltitudeAccuracy
        {
            get { return 100.0; }
        }
        #endregion
    }
    public class TelephoneMP3 : ProductComponentBase, ISmartPhone
    {
        ITelephone telephone;
        IMp3Player mp3Player;
        public TelephoneMP3()
            : base("TelephoneMP3")
        {
            this.telephone = new Telephone();
            this.mp3Player = new MP3();
        }
        IEnumerable<IProductComponent> BaseChildComponents
        {
            get
            {
                return base.ChildComponents;
            }
        }
        public override IEnumerable<IProductComponent> ChildComponents
        {
            get
            {
                if (Telephone != null)
                    yield return Telephone;
                if (Mp3Player != null)
                    yield return Mp3Player;
                foreach (var child in BaseChildComponents)
                    yield return child;
            }
        }
        #region ISmartPhone Members
        public ITelephone Telephone
        {
            get { return telephone; }
        }
        public IMp3Player Mp3Player
        {
            get { return mp3Player; }
        }
        #endregion
    }
    public class MP3 : ProductComponentBase, IMp3Player
    {
        public MP3()
            : base("mp3Player")
        {
        }
    }

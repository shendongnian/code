    /// <summary>
    /// name: Building
    /// </summary>
    public class Building
    {
        /// <summary>
        /// name of building
        /// </summary>
        public virtual string Name
        {
            get
            {
                // default name is class name with spaces between upper letters
                StringBuilder sb = new StringBuilder();
                bool wasUpper = false;
                foreach (char c in this.GetType().Name)
                {
                    if (char.IsUpper(c))
                    {
                        if (!wasUpper)
                        {
                            sb.Append(' ');
                            wasUpper = true;
                        }
                    }
                    else
                    {
                        wasUpper = false;
                    }
                    sb.Append(c);
                }
                return sb.ToString().Trim();
            }
        }
        public void Construct()
        {
            string buildingName = this.Name;
            // do some work
        }
    }
    
    /// <summary>
    /// name: Missile Station
    /// </summary>
    public class MissileStation : Building { }
    
    /// <summary>
    /// name: Radar Station "Buk"
    /// </summary>
    public class RadarBuk : Building
    {
        /// <summary>
        /// overriden building name
        /// </summary>
        public override string Name { get { return @"Radar Station ""Buk"""; } }
    }

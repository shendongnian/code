        public class Person : IPerson
        {
            IPerson[] _rolles;
            IPerson _chosenStrategy;
            public Person()
            {
                this._rolles =
                    new IPerson[] { new Leader(this), new Secretary(this), new Parent(this) };
                this._chosenStrategy = this._rolles[0];
            }
            public bool Is(Type type)
            {
                return this._rolles.Any(r => r.GetType() == type);
            }
            private void SetStrategy(Type type)
            {
                this._chosenStrategy = this._rolles.Where(r => r.GetType() == type).FirstOrDefault();
            }
            /*Rest of Implementation goes here*/
        }

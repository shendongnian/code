        public class Person : IPerson
        {
            List<IPerson> _rolles;
            IPerson _chosenStrategy;
            public Person()
            {
                this._rolles =
                    new List<IPerson>() { new Leader(this), new Secretary(this), new Parent(this) };
                this._chosenStrategy = this._rolles[0];
            }
            public void AddRole(Func<Person, IPerson> creator) {
                  IPerson newRole = creator(this)
                  //You can choose to remove duplicate roles by uncommenting the following line:
                  //this.RemoveRole(newRole.GetType());
                  this._rolles.Add(newRole);
            }
            public void RemoveRole(Type type) {
                  this._rolles.RemoveAll(r => r.GetType() == type);
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

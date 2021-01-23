    using System;
    using System.Collections.Generic;
    // some fake classes just so I can compile the example
    class Baseclass {
        public bool IsValid {
            get { return true; }
        }
    }
    class Subclass1 : Baseclass {
    }
    class Subclass2 : Baseclass {
    }
    class Program {
        static void Main(string[] args) {
            var subclassList = new List<Type>() {
               typeof(Subclass1),
               typeof(Subclass1)
            };
            List<Baseclass> objectList = new List<Baseclass>();
            foreach (Type subclass in subclassList) {
                Baseclass newObject = (Baseclass)Activator.CreateInstance(subclass);
                if (newObject.IsValid) {
                    objectList.Add(newObject);
                }
            }
        }
    }

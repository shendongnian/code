    public abstract class Person : ICloneable {
                 public virtual object Clone() {
                  //all upper classes is a Person object
                  person = (Person)Activator.CreateInstance(this.GetType());
                        person.job = this.job; 
                        // ect more properties Lazy or Deep clone
                        person.blah = this.blah;
                        return person;
                    }
               }
    
    public abstract class Adult : Person {
          override object Clone() {
                        Adult adult =  (Adult) base.Clone();
                        adult.job = this.job;
                    }
              }

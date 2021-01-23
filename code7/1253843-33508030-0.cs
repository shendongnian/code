    public abstract class Person : ICloneable {
                 public virtual object Clone() {
                        return Activator.CreateInstance(this.GetType());
                    }
               }
    
    public abstract class Adult : Person {
          override object Clone() {
                        Adult adult =  (Adult) base.Clone();
                        adult.job = this.job;
                    }
              }

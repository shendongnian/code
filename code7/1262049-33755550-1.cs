    interface ICloneableExtended<T> : ICloneable {
        T Clone();
    }
    abstract class Cloneable<T> : ICloneableExtended<T> {
        public virtual T Clone() {
            using (var ms = new MemoryStream()) {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(ms);
            }
        }
        object ICloneable.Clone() {
            return Clone();
        }
    }
    sealed class Car : Cloneable<Car> { }

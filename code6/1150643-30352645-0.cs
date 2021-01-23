    public class MyList<T> : List<T>
    {
        public T this[int i]
        {
            get { 
                while (i > this.Length) this.Add(default(T));
                return base[i]; 
            }
            set { 
                while (i > this.Length) this.Add(default(T));
                base[i] = value; 
            }
        }
    }

    List<MyData> mycopy = new List<MyData>();
    data.ForEach((item)=>
        {
            mycopy.Add(new MyData(item));
        });
    public class MyData
    {
        public MyData(string nombre, string tipo, int longitud)
        {
            Nombre = nombre;
            Tipo = tipo;
            Longitud = longitud;
        }
        public MyData(MyData itemToCopy)
        {
            Nombre = itemToCopy.Nombre;
            Tipo = itemToCopy.Tipo;
            Longitud = itemToCopy.Longitud;
        }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Longitud { get; set; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((MyData)obj);
        }
        protected bool Equals(MyData other)
        {
            return string.Equals(this.Nombre, other.Nombre) && string.Equals(this.Tipo, other.Tipo) && this.Longitud == other.Longitud;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (this.Nombre != null ? this.Nombre.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Tipo != null ? Tipo.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ this.Longitud;
                return hashCode;
            }
        }
    }

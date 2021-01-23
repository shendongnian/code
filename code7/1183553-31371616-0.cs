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
    }

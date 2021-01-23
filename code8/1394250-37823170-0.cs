    public class T
    {
        public string nit { get; set; }
        public string nombrecliente { get; set; }
        public string nombresitio { get; set; }
        public string direccion { get; set; }
        public string titulo {
            get {
                var temp = agregarTexto ("", "NIT: " + nit);
                return agregarTexto (temp, "Cliente: " + nombrecliente);
            }
        }
    }

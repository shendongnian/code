    public class PermisoModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public bool Checked { set; get; }
    }
    public class ModuloModel
    {
        public int Id { set; get; }
        public List<PermisoModel> Permisos { get; set; }
    }

     public class Resource
        {
            public int Id { get; set; }
            public int? ModuleId { get; set; }
            public Module Module { get; set; }
            public virtual ICollection<Module> IsSpecialForModules { get; set; }
        }

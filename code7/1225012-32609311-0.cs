    public class Prescricao
    {
        // Hidden Properties
        /// <summary>
        /// Remédios prescritos para o paciente.
        /// </summary>
        public virtual ICollection<Remedio> Remedios { get; set; }
        public Prescricao()
        {
            Remedios = new List<Remedio>();
        }
    }
    public class Remedio
    {
        /// <summary>
        /// Prescrições que incluem o remédio.
        /// </summary>
        public virtual ICollection<Prescricao> Prescricoes { get; set; }
        public Remedio()
        {
            Prescricoes = new List<Prescricao>();
        }

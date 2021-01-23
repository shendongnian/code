    [Route("/turno", "Post")]
    public class EventoCliente : IReturn<EventoClienteResponse>
    {
        public TurnoCliente Turno { get; set; }
        public string Sucursal { get; set; }
        public string[] Puestos { get; set; }
        public DateTime? TimeReceived { get; set; }
    }

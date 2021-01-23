    // Usuario.cs
    public string Message { get; set; }
    ...
    Silabas silabas = new Silabas(this);
    
    // Silabas.cs
    public Silabas(Usuario usuario)
    {
      // Here you can access the usuario.Message
    }

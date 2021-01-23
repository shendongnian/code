    public List<string> getClientes()
    {
       using (var context = new Model.CivarTransporteModelContainer())
       {
           return context.Cliente.Select(x=>x.Name).ToList();    
       }
    }

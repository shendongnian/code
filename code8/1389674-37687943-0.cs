    lista = (from p in listaDB
         select new ItemAcciones
         {
            ID_Accion = p.ID_Accion,
    
            FechaHora =  p.FechaHora != null ? (DateTime)p.FechaHora : DateTime.Now,
            ShowFechaHora = !String.IsNullOrWhiteSpace(((DateTime)p.FechaHora).ToString("HH:mm")) ? ((DateTime)p.FechaHora).ToString("HH:mm") : DateTime.Now.ToString("HH:mm"),

        var resp = db.Comentario
                .Where(c => c.Id == com.Id)
                .Select(c => new {
                    c.Id,
                    Usuario = new {
                        c.Usuario.Nombre,
                        c.Usuario.Apellidos,
                        c.Usuario.Avatar,
                        c.Usuario.Nickname
                    },
                    c.Contenido,
                    Fecha = c.Fecha.ToShortDateString(),

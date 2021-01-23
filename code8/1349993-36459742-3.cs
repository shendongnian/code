        var resp = db.Comentario
                .Where(c => c.Id == com.Id)
                .Select(c => new {   // <<< Here you're still querying the
                    c.Id,            //     database, nothing has been received / executed yet.
                    Usuario = new {
                        c.Usuario.Nombre,
                        c.Usuario.Apellidos,
                        c.Usuario.Avatar,
                        c.Usuario.Nickname
                    },
                    c.Contenido,
                    Fecha = c.Fecha.ToShortDateString(),

          var resp = db.Comentario
                    .Include(u=>u.Usuario) // with this Usuario is no longer null
                    .Where(c => c.Id == com.Id && c.IdEstado != 3)
                    .ToList()
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
                        R = c.IdEstado == 1 ? false : true
                    });

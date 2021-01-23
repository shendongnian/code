    [ResponseType(typeof(Usuario))]
    public IHttpActionResult GetUsuario(int id)
    {
        Usuario usuario = db.Usuarios.Find(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return Ok(usuario.Map());
    }

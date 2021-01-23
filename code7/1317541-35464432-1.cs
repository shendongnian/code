    public class UsuariosApp : IDisposable
    {
        private DBControleDeAcesso db { get; set; }
        public UsuariosApp()
        {
            db = new DBControleDeAcesso();
        }
        public void SalvarUsuario(Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }
        public Perfil LocalizarPerfil(int id)
        {
            return db.Perfis.Find(id);
        }
        public IEnumerable<Perfil> LocalizarPerfiles( IEnumerable<int> ids )
        {
            return db.Perfils.Where( p => ids.Contains( p.Id ) )
                .ToArray();
        }
        private bool _disposed = false;
        protected virtual void Dispose( bool disposing )
        {
            if( _disposed )
            {
                return;
            }
            if( disposing )
            {
                db.Dispose();
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }
    }
    public ActionResult CriarUsuarioNaApp( UsuarioViewModel model )
    {
        // validate model state first
        if( ModelState.IsValid )
        {
            // use single, disposable repo/uow instance
            using( var uapp = new UsuariosApp() )
            {
                // get all profiles in a single call, no loop required
                var perfils = uapp.LocalizarPerfiles( model.PerfisSelecionados );
    
                model.Usuario.Perfis.AddRange( perfils );
    
                uapp.SalvarUsuario( model.Usuario );
            }
    
            return RedirectToAction( "Usuarios" );
        }
    
        return View( model );
    }

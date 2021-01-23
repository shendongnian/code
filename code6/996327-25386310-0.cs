    UsuariosViewModel vm = new UsuariosViewModel
        {
            Usuarios = manager.Users.Where(m => m.Ativo)
            .OrderBy(m => m.Nome)
            .Skip((pagina - 1) * UsuariosPorPagina)
            .Take(UsuariosPorPagina)
            .ToList(),
    
            Paginacao = new Paginacao
            {
                PaginaAtual = pagina,
                ItensPorPagina = UsuariosPorPagina
            }
        };

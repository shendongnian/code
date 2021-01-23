    public ActionResult CadastrarFilho()
    {
      .
      .      
       ViewBag.CategoriasPai = new SelectList(_servicoAppGerenciadorCategoriaFinanceira.ListarPorEmpresa(TokenAcesso, empresa.EmpresaID), "CategoriaFinanceiraID",  "Nome");
    
       return PartialView(viewModel);
    }

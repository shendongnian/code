    [HttpPost]
        public ActionResult Carrinho(string hidCarrinho)
        {
            List<ItemCarrinho> listaCarrinho = new List<ItemCarrinho>();
            if (hidCarrinho != null)
            {
                var itens = JsonConvert.DeserializeObject<List<ItemCarrinho>>(hidCarrinho);
                foreach (var item in itens)
                {
                    var qtd = int.Parse(new string(item.qtdProduto.ToString().Where(char.IsDigit).ToArray()));
                    if (qtd > 0)
                    {
                        var idLivroNumerico = int.Parse(new string(item.idLivro.ToString().Where(char.IsDigit).ToArray()));
                        var resultado = db.Produtos.Where(m => m.idProduto == idLivroNumerico).FirstOrDefault();
                        ItemCarrinho prod = new ItemCarrinho();
                        prod.idLivro = idLivroNumerico;
                        prod.qtdProduto = qtd;
                        prod.nomeProduto = resultado.nomeProduto;
                        prod.descProduto = resultado.descProduto;
                        prod.precProduto = resultado.precProduto;
                        prod.descontoPromocao = resultado.descontoPromocao;
                        prod.imagem = resultado.imagem;
                        listaCarrinho.Add(prod);
                    }
                }
            }
            return View(listaCarrinho);
        }

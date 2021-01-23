    if(listaDeInformacaoNode.Nodes.Count >= posicaoNodo)
    {
        listaDeInformacaoNode.Nodes[posicaoNodo].Nodes.Add(CampoInformacao);
        listaDeInformacaoNode.Nodes[posicaoNodo].Nodes.Add(ValorInformacao);
        listaDeInformacaoNode.Nodes[posicaoNodo].Nodes.Add(TipoDeDadoInformacao);
    }

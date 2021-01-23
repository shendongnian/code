    string nomePesquisa = entryNmPesq.Text;
    var nomePesqCripto = Crypto.EncryptAes(nomePesquisa, hash, salt);
    string nomepesquisa = Uri.EscapeDataString(Convert.ToBase64String(nomePesqCripto));
    if (!String.IsNullOrEmpty(nomepesquisa))
    {
        ApiCall apiCall = new ApiCall();
        apiCall.GetResponse<List<Envolvido>>("nomes", "Envolvidos", nomepesquisa);
    }

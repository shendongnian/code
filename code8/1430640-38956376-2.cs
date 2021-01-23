    string nomePesquisa = entryNmPesq.Text;
    string nomeApiCall = String.Empty;
    if (!String.IsNullOrEmpty(nomePesquisa))
    {
      var nomePesqCripto = Crypto.EncryptAes(nomePesquisa, hash, salt);
      nomeApiCall = Uri.EscapeDataString(Convert.ToBase64String(nomePesqCripto));
    }
    ApiCall apiCall = new ApiCall();
    apiCall.GetResponse<List<Envolvido>>("nomes", "Envolvidos", nomeApiCall);

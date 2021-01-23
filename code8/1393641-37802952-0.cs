    private string _senha;
    public string Senha 
    {
        get { return _senha; }
        set 
        { 
            Console.WriteLine("valor"+value );
            _senha = CalculateMD5Hash(value);
        }
    }

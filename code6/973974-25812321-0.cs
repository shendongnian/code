    public HttpResponseMessage Products(int productId,string ptype="Clothes")
    {
        TypeEnum category = TypeEnum.Clothes;
        if(!Enum.TryParse(ptype, true, out category))
          //throw bad request exception if you want. but it is fine to pass-through as default Cloathes value.
        else
          //continue processing
    }

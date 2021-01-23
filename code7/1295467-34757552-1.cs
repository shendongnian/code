    public TransactionResult Cook(PizzDto pizza)
    {
       if (!BLL.Pizza.NameExists(pizza.name))
       {
         return new TransactionResult { ErrorCode= "NameExists"};
       }
       BLL.Pizza.KeepInOven(pizza);
       return new TransactionResult { IsSuccess = true };   
    }

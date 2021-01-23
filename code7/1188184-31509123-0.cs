        readonly ITransactionRepository repository;
        public SaveTransactionCommandHandler(ITransactionRepository repository)
        {
              this.repository = repository;
        }
        public void Handle(SaveTransactionCommand command)
        {
      
                repository.Save(new Transaction
                {
                    GiftCardId = command.GiftCardId, 
                    TransactionTypeId = Convert.ToInt32(command.TransactionTypeId), 
                    Amount = command.Amount,
                    TransactionDate = DateTime.Now
                });
               
        }
    }  

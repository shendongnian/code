    public virtual NotifyTask<ObservableCollectionCore<Merchant>> Merchants { get; set; }
    public MerchantViewModel()
    {
      Merchants = NotifyTask.Create(Task.Run(() => SQLite.GetMerchants()));
    }

    public class ConsultInvoiceViewModel : ViewModelBase
        {
    
          public Context ctx = new Context();
    
          private ICollectionView _dataGridCollection;
          private ObservableCollection<Invoice> invoiceCollection;
    
    
          public ConsultInvoiceViewModel()
          {
            invoiceCollection = new ObservableCollection<Invoice>();
            DataGridCollection = CollectionViewSource.GetDefaultView(Get());        
    
            if (!WPFHelper.IsInDesignMode)
            {
                var tsk = Task.Factory.StartNew(InitialStart);
                tsk.ContinueWith(t => { MessageBox.Show(t.Exception.InnerException.Message); }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
    
         private void InitialStart()
         {
             try
             {
              State = StateEnum.Busy;
              Get();
              }
              finally
              {
              State = StateEnum.Idle;
              }
         }
    
          private void SearchFilter()
          {
    
                                    Task tsk = Task.Factory.StartNew(()=>
                                                                        {
                                             try
                                                {
                                                 State = StateEnum.Busy;
                                                 using (var ctx = new Context())
                                                 {
    
                                                      var invs = ctx.Invoices
                                                                 .Where(s.supplier == 1)
                                                                 .GroupBy(x => new { x.suppInvNumber, x.foodSupplier })
                                                                 .ToList()
                                                                 .Select(i => new Invoice
                                                                              {
                                                                               suppInvNumber = i.Key.suppInvNumber,
                                                                               foodSupplier = i.Key.foodSupplier,
                                                                               totalPrice = i.Sum(t => t.totalPrice),
                                                                               });
                                                                 .
    
                                                App.Current.Dispatcher.Invoke((Action)delegate 
                                               {
                                                    invoiceCollection.Clear();
                                                    if (invs != null)
                                                           foreach (var inv in invs)
                                                           {
                                                         invoiceCollection.Add(inv);
                                                           }
                                                });
    
                                                           
                                                 }
                                                 }
                                                 finally
                                                 {
                                                  State = StateEnum.Idle;
                                                 }
    
                        });
                                    tsk.ContinueWith(t => { MessageBox.Show(t.Exception.InnerException.Message); }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
                                }
    
            private ObservableCollection<Invoice> Get()
            {
                DateTime inTwoMonth = DateTime.Now.AddMonths(-2);
                using (var ctx = new Context())
                {
                    var invs = ctx.Invoices
                                .GroupBy(x => new { x.suppInvNumber, x.shop1, x.date, x.foodSupplier })
                                .ToList()
                                .Select(i => new Invoice
                                {
                                    suppInvNumber = i.Key.suppInvNumber,
                                    shop1 = i.Key.shop1,
                                    date = i.Key.date,
                                    foodSupplier = i.Key.foodSupplier,
                                    totalPrice = i.Sum(t => t.totalPrice),
                                })
                                .Where(d => d.date >= inTwoMonth)
                                .OrderByDescending(d => d.date)
                                .AsQueryable();
                    
                        foreach (var inv in invs)
                        {
                            App.Current.Dispatcher.Invoke((Action)delegate 
                            {
                                invoiceCollection.Add(inv);
                            });
                        }
                }

        public pgSysproStock()
        {
            InitializeComponent();
            SysproStock.WindowState = WindowState.Normal;
            
            this.UpdateStockAsync();
        }
        
        private async void UpdateStockAsync()
        {
            dgSysproStock.IsEnabled = false;
        
            using (TruckServiceClient TSC = new TruckServiceClient())
            {
                var allStock = await TSC.GetSysproStockAsync();
        
                dgSysproStock.ItemsSource = allStock.Select(item =>
                            new AllStock
                                {
                                    Id = item.Id,
                                    StockCode = item.StockCode,
                                    Description = item.Description,
                                    ConvFactAltUom = item.ConvFactAltUom,
                                    ConvMulDiv = item.ConvMulDiv,
                                    ConvFactOthUom = item.ConvFactOthUom,
                                    MulDiv = item.MulDiv,
                                    Mass = item.Mass,
                                    Updated_Supplier = item.Updated_Supplier,
                                    CycleCount = item.CycleCount,
                                    ProductClass = item.ProductClass.ToString(),
                                    UnitCost = item.UnitCost,
                                    Discount = item.Discount,
                                    Warehouse = item.Warehouse,
                                    MinimumStock = item.MinimumStock,
                                    MaximumStock = item.MaximumStock,
                                    StockForNow = item.StockForNow,
                                    CoilWidth = item.CoilWidth,
                                    SheetCoilLength = item.SheetCoilLength,
                                    MaterialThickness = item.MaterialThickness
                            }).ToArray();
    
            dgSysproStock.IsEnabled = true;
        }
    }

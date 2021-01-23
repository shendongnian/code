    public class CustomTaxClassInfoProvider : TaxClassInfoProvider
    {
        #region Properties
        private ShoppingCartInfo Cart
        {
            get 
            {
                return ECommerceContext.CurrentShoppingCart;
            }
        }
        private string CustomerZipCode
        {
            get 
            {
                AddressInfo customerAddress = AddressInfoProvider.GetAddressInfo(Cart.ShoppingCartShippingAddressID);
                if(customerAddress != null)
                    return customerAddress.AddressZip;
                return null;
            }
        }
        #endregion
        /// <summary>
        /// Returns DataSet with all the taxes which should be applied to the shopping cart items.
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        protected override DataSet GetTaxesInternal(ShoppingCartInfo cart)
        {
            DataSet taxDataSet = new DataSet();
            // Create an empty taxes table
            DataTable table = GetNewTaxesTable();
            List<TaxRow> taxRows = new List<TaxRow>();
            foreach (ShoppingCartItemInfo item in cart.CartItems)
            {
                TaxRow row = new TaxRow();
                row.SKUID = item.SKU.SKUID;
                row.SKUGUID = item.SKU.SKUGUID;
                taxRows.Add(row);
            }
            foreach (TaxRow row in taxRows)
            {
                double rate = 0;
                string name = "";
                // Add conditions for different tax rates here
                // --------------------------------------------
                // For Example
                if (cart.Customer.CustomerCountryID == countryYouWantToExclude)
                {
                    rate = yourTaxRate;
                    name = "Name for the tax";
                }
                else
                {
                    rate = 0;
                    name = "";
                }
                row.TaxRate = rate;
                row.TaxName = name;
            }
            BuildTaxTable(ref table, taxRows);
            
            // Return our dataset with the taxes
            taxDataSet.Tables.Add(table);
            return taxDataSet;
        }
        private void BuildTaxTable(ref DataTable table, List<TaxRow> taxRows)
        {
            foreach (TaxRow row in taxRows)
            {
                AddTaxRow(table, row.SKUID, row.TaxName, row.TaxRate);
            }
        }
        
        private DataTable GetNewTaxesTable()
        {
            DataTable table = new DataTable();
            // Add required columns
            table.Columns.Add("SKUID", typeof(int));
            table.Columns.Add("TaxClassDisplayName", typeof(string));
            table.Columns.Add("TaxValue", typeof(double));
            return table;
        }
        private void AddTaxRow(DataTable taxTable, int skuId, string taxName, double taxValue, bool taxIsFlat, bool taxIsGlobal, bool zeroTaxIfIDSupplied)
        {
            DataRow row = taxTable.NewRow();
            // Set required columns
            row["SKUID"] = skuId;
            row["TaxClassDisplayName"] = taxName;
            row["TaxValue"] = taxValue;
            // Set optional columns
            //row["TaxIsFlat"] = taxIsFlat;
            //row["TaxIsGlobal"] = taxIsGlobal;
            //row["TaxClassZeroIfIDSupplied"] = taxIsGlobal;
            taxTable.Rows.Add(row);
        }
        private void AddTaxRow(DataTable taxTable, int skuId, string taxName, double taxValue)
        {
            AddTaxRow(taxTable, skuId, taxName, taxValue, false, false, false);
        }
    }
    /// <summary>
    /// Represents a DataRow to be inserted into the tax calculation data table
    /// </summary>
    public class TaxRow
    {
        public int SKUID { get; set; }
        public Guid SKUGUID { get; set; }
        public string TaxName { get; set; }
        public double TaxRate { get; set; }
        public TaxRow()
        {
        }
    }

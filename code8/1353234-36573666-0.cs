    using System;
    using System.Data;
    using System.Windows.Forms;
    
    namespace Samples
    {
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var form = new Form();
    
    
    			DataSet dsOrders = new DataSet("dsOrders");
    
    			//SqlDataAdapter daOrderHeader;// = new SqlDataAdapter();
    			//SqlDataAdapter daOrderDetail;// = new SqlDataAdapter();
    
    			BindingSource bsOrderHeader = new BindingSource();
    			BindingSource bsOrderDetail = new BindingSource();
    
    			DataTable dtOrderHeader = new DataTable("dtOrderHeader");
    			DataTable dtOrderDetail = new DataTable("dtOrderDetail");
    
    			dsOrders.Tables.Add(dtOrderHeader);
    			dsOrders.Tables.Add(dtOrderDetail);
    
    			//daOrderHeader = DataAdapterOrderHeader();
    			//daOrderDetail = DataAdapterOrderDetail();
    
    			//daOrderHeader.Fill(dtOrderHeader);
    			//daOrderDetail.Fill(dtOrderDetail);
    			dtOrderHeader.Columns.Add("ID", typeof(int));
    			dtOrderHeader.Columns.Add("Name", typeof(string));
    			dtOrderHeader.Columns.Add("TaxRate", typeof(decimal));
    			dtOrderHeader.Columns.Add("Shipping", typeof(string));
    			dtOrderHeader.Columns.Add("ExchangeRate", typeof(decimal));
    			dtOrderHeader.Columns.Add("OrderDate", typeof(DateTime));
    			dtOrderHeader.Columns.Add("PriceCode", typeof(int));
    
    			dtOrderHeader.PrimaryKey = new[] { dtOrderHeader.Columns["ID"] };
    
    			dtOrderDetail.Columns.Add("OrderId", typeof(int));
    			dtOrderDetail.Columns.Add("Quantity", typeof(decimal));
    
    			////Set up a master-detail relationship between the DataTables
    			DataColumn keyOrderHeaderColumn = dsOrders.Tables["dtOrderHeader"].Columns["ID"];
    			DataColumn foreignKeyOrderDetailColumn = dsOrders.Tables["dtOrderDetail"].Columns["OrderId"];
    			var rel = dsOrders.Relations.Add("rOrders", keyOrderHeaderColumn, foreignKeyOrderDetailColumn);
    
    			bsOrderHeader.DataSource = dsOrders;
    			bsOrderHeader.DataMember = "dtOrderHeader";
    			bsOrderDetail.DataSource = bsOrderHeader;
    			bsOrderDetail.DataMember = "rOrders";
    
    			var splitView = new SplitContainer { Dock = DockStyle.Fill, Parent = form };
    			var tbxOrderNo = new TextBox();
    			var tbxCustomer = new TextBox();
    			var tbxTaxRate = new TextBox();
    			var tbxShipping = new TextBox();
    			var tbxExchangeRate = new TextBox();
    			var dtpOrderDate = new DateTimePicker();
    			int y = 8;
    			foreach (var c in new Control[] { tbxOrderNo, tbxCustomer, tbxTaxRate, tbxShipping, tbxExchangeRate, dtpOrderDate })
    			{
    				c.Top = y;
    				c.Left = 16;
    				splitView.Panel1.Controls.Add(c);
    				y = c.Bottom + 8;
    			}
    
    			var dgvItems = new DataGridView { Dock = DockStyle.Fill, Parent = splitView.Panel2 };
    			
    			tbxOrderNo.DataBindings.Add("Text", bsOrderHeader, "ID");
    			tbxCustomer.DataBindings.Add("Text", bsOrderHeader, "Name");
    			tbxTaxRate.DataBindings.Add("Text", bsOrderHeader, "TaxRate");
    			tbxShipping.DataBindings.Add("Text", bsOrderHeader, "Shipping");
    			tbxExchangeRate.DataBindings.Add("Text", bsOrderHeader, "ExchangeRate");
    			dtpOrderDate.DataBindings.Add("Text", bsOrderHeader, "OrderDate");
    			//cbxPriceCode.DataBindings.Add("SelectedIndex", bsOrderHeader, "PriceCode");
    			dgvItems.DataSource = bsOrderDetail;
    
    
    			Func<DataRow> addOrder = () =>
    			{
    				var maxOrderId = dsOrders.Tables["dtOrderHeader"].Compute("max(ID)", string.Empty);
    				int newOrderId =  (maxOrderId != null && maxOrderId != DBNull.Value ? Convert.ToInt32(maxOrderId) : 0) + 1;
    				DataRow drOrderHeader = dsOrders.Tables["dtOrderHeader"].NewRow();
    				drOrderHeader["ID"] = newOrderId;
    				dsOrders.Tables["dtOrderHeader"].Rows.Add(drOrderHeader);
    				DataRow drOrderDetail = dsOrders.Tables["dtOrderDetail"].NewRow();
    				drOrderDetail["OrderId"] = newOrderId;
    				dsOrders.Tables["dtOrderDetail"].Rows.Add(drOrderDetail);
    				return drOrderHeader;
    			};
    
    			for (int i = 0; i < 5; i++) addOrder();
    
    			var addButton = new Button { Dock = DockStyle.Bottom, Parent = form, Text = "Add" };
    			addButton.Click += (sender, e) =>
    			{
    				var drOrderHeader = addOrder();
    				bsOrderHeader.Position = bsOrderHeader.Find("ID", drOrderHeader["ID"]);
    			};
    
    			Application.Run(form);
    		}
    	}
    }

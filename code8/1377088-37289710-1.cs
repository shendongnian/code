        private void GetOrderList()
        {
            DataTable dt = GetOrderListData();
            gvCustomerOrders.DataSource = dt;
            gvCustomerOrders.DataBind();
            gvCustomerOrders.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        private DataTable GetOrderListData()
        {
            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("CustomerName");
            dt.Columns.Add("CustomerPhoneNo");
            dt.Columns.Add("TotalProducts", typeof(int));
            dt.Columns.Add("TotalPrice", typeof(decimal));
            dt.Rows.Add(1, "TEST1", "123123", 10, 100M);
            dt.Rows.Add(2, "TEST2", "123123", 20, 200M);
            dt.Rows.Add(3, "TEST3", "123123", 30, 300M);
            dt.Rows.Add(4, "TEST4", "123123", 40, 400M);
            return dt;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetOrderList();
            }
        }

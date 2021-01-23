    lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo()
            {
                FieldName = "StartDate",
                FormatType = DevExpress.Utils.FormatType.DateTime,
                FormatString = "d" // short datetime
            });
    lookUpEdit1.Properties.DataSource = new List<Order> { 
        new Order(){ StartDate = new DateTime(2015, 03, 23, 23, 0, 0) },
        new Order(){ StartDate = new DateTime(2015, 03, 24, 23, 0, 0) },
        new Order(){ StartDate = new DateTime(2015, 03, 25, 23, 0, 0) },
    };

    @{    
    List<PaymentOption> myPaymentOptionList = ViewBag.PaymentOptionGridSource;
    WebGrid paymentOptionWebGrid = new WebGrid(
        null,
        canPage: true,
        defaultSort: "ID"
        );
    paymentOptionWebGrid.Bind(
        myPaymentOptionList,
        autoSortAndPage: true
        );
	}
    @paymentOptionWebGrid.GetHtml (
	tableStyle: "table table-hover table-bordered table-responsive",
	columns: paymentOptionWebGrid.Columns(
		paymentOptionWebGrid.Column("PaymentOptionDescription", "Payment Method", style: "span1", canSort: false),
		paymentOptionWebGrid.Column("MyPaymentOptionModelPropertyHere", "My Column Header Here", style: "span2", canSort: false),
		
		/* Same logic for all other columns as above */
		
		)

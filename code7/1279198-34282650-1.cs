	string WhrCond = "";
	if(isNumeric(textBox2.Text))
	{
		WhrCond = "product_Id = " + textBox2.Text.Trim() ;
	}
	else
	{
		WhrCond = "product_Name LIKE %'" + textBox2.Text.Trim() + "'%";
	}
	if(string.IsNullOrEmpty(textBox2.Text))
	{
		WhrCond = "1 = 1";
	}
	SqlConnection con = new SqlConnection("Data Source=SUMIT;Initial Catalog=Project;Integrated Security=True");
	SqlDataAdapter a = new SqlDataAdapter("select product_Name as [Product Name],
							actual_Cost as [Actual Cp], 
							Margin, 
							actual_Sp as [Actual SP], 
							product_Id as [Product Id], 
							purchase_Price as [Purchase Price], 
							discount as [Discount], 
							beforevat_Price as [Before Vat Price],
							vat_Rate as [Vat%] from Product WHERE " + WhrCond , con);
	DataTable b = new DataTable();
	a.Fill(b);
	dataGridView1.DataSource = b;
	textBox3.Focus();

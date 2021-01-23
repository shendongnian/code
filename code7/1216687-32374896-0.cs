	var fiscalReceipt = new XElement("FiscalRecipet");
	var receipt = new XDocument(new XDeclaration("1.0", "utf-8", null), fiscalReceipt);
	for (int i = 0; i < 5; i++)
	{
		var enternode = new XElement("FiscalItem",
			new XElement("Name", "foo"),
			new XElement("Price", i * 100),
			new XElement("Quantity", 1),
			new XElement("TaxGroup", "A"));
		fiscalReceipt.Add(enternode);
	}
	Console.WriteLine(receipt);
----------
	<FiscalRecipet>
	  <FiscalItem>
		<Name>foo</Name>
		<Price>0</Price>
		<Quantity>1</Quantity>
		<TaxGroup>A</TaxGroup>
	  </FiscalItem>
	  <FiscalItem>
		<Name>foo</Name>
		<Price>100</Price>
		<Quantity>1</Quantity>
		<TaxGroup>A</TaxGroup>
	  </FiscalItem>
	  <FiscalItem>
		<Name>foo</Name>
		<Price>200</Price>
		<Quantity>1</Quantity>
		<TaxGroup>A</TaxGroup>
	  </FiscalItem>
	  <FiscalItem>
		<Name>foo</Name>
		<Price>300</Price>
		<Quantity>1</Quantity>
		<TaxGroup>A</TaxGroup>
	  </FiscalItem>
	  <FiscalItem>
		<Name>foo</Name>
		<Price>400</Price>
		<Quantity>1</Quantity>
		<TaxGroup>A</TaxGroup>
	  </FiscalItem>
	</FiscalRecipet>
	Press any key to continue . . .

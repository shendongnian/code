    var context = new TestContext();
    var block = new Block { Description = "Block 1" };
    var invoices = new List<Invoice>
                        {
                            new Invoice { Description = "Invoice 1" },
                            new Invoice { Description = "Invoice 2" }
                        };
    invoices.ForEach(i => block.Invoices.Add(i));
    context.Blocks.Add(block);
    context.SaveChanges();
    block = null;
    var invoice = context.Invoices.First();
    invoice.Block = null;
    context.SaveChanges();

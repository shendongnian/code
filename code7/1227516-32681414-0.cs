    //itemlist
            {
                var invoiceItems = new List<InvoiceItem>();
                //override
                foreach (var line in invoice.SaleInvoiceLines)
                {
                    //soline
                    var soitem = (from t in nsSaleOrder.itemList.item
                                  where t.item.internalId == line.PurchaseOrderLine.ProductSupplier.Product.NSInternalID
                                  && t.poVendor.internalId == line.PurchaseOrderLine.ProductSupplier.Supplier.NSInternalID
                                  select t).FirstOrDefault();
                    if (soitem != null)
                    {
                        //invoice item
                        var invoiceItem = new InvoiceItem();
                        invoiceItem.item = soitem.item;
                        invoiceItem.orderLine = soitem.line;
                        invoiceItem.orderLineSpecified = true;
                        invoiceItem.isTaxable = true;
                        invoiceItem.isTaxableSpecified = true;
                        invoiceItem.quantity = line.Quantity;
                        invoiceItem.quantitySpecified = true;
                        invoiceItem.tax1Amt = line.Tax;
                        invoiceItem.tax1AmtSpecified = true;
                        //price
                        RecordRef plRef = new RecordRef();
                        plRef.type = RecordType.priceLevel;
                        plRef.typeSpecified = true;
                        plRef.internalId = "-1";
                        invoiceItem.price = plRef;
                        invoiceItem.rate = "" + line.UnitPrice;
                        invoiceItems.Add(invoiceItem);
                    }
                    else
                    {
                        throw new Exception(string.Format("Product [{0}] from Supplier [{1}] is missing",
                            line.PurchaseOrderLine.ProductSupplier.Product.Code,
                            line.PurchaseOrderLine.ProductSupplier.Supplier.Code));
                    }
                }
                var itemReceiptItemList = new InvoiceItemList();
                itemReceiptItemList.item = invoiceItems.Where(t=>t.quantity>0).ToArray();
                itemReceiptItemList.replaceAll = true;
                nsInvoice.itemList = itemReceiptItemList;
            }

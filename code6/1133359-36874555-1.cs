                var payment = new Payment ();  //Quickbooks Payment Entity                
                payment.CustomerRef = new ReferenceType()
                {
                    type = Enum.GetName(typeof(objectNameEnumType), objectNameEnumType.Customer),
                    Value = "<qbCustomerId>",
                    name = "<CustomerName>"
                };
                 
                var linkedTxn = new List<LinkedTxn>
                {
                    new LinkedTxn
                    {
                        TxnId = "<invoice QuickBooksId>",
                        TxnType = objectNameEnumType.Invoice.ToString(),
                    }
                };
                var line = new List<Line>
                {
                    new Line
                    {
                        Amount = amount,
                        LinkedTxn = linkedTxn.ToArray(),
                        AmountSpecified = true                                      
                    }
                };
                payment.Line = line.ToArray();
                payment.TotalAmt = amount;
                payment.TotalAmtSpecified = true;
                var result = Insert(payment);

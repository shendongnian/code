    var list = (from x in Context.tblProduct
                group x by new { x.OrderNo, x.Color } into groupedByColorCode
                select new
                    {
                        OrderNo = groupedByColorCode.Key.OrderNo,
                        ProductRef = groupedByColorCode.FirstOrDefault().ProductRef,
                        Color = groupedByColorCode.Key.Color,
                        Size = String.Join("", groupedByColorCode.Select(bcc => bcc.Size), // This line doesn't work
                        TotalQuantity = groupedByColorCode.Sum(bcc => bcc.OriQty).ToString()
                    });

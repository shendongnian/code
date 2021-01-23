                                        <table class="inventory">
                                        <thead>
                                            <tr>
                                                <th width="180"><span>Code</span></th>
                                                <th width="265"><span>Description</span></th>
                                                <th><span>Price</span></th>
                                                <th><span>Quantity</span></th>
                                                <th><span>Discount %</span></th>
                                                <th><span>Discount Amt</span></th>
                                                <th><span>Net £</span></th>
                                                <th><span>Tax %</span></th>
                                                <th><span>VAT Amt</span></th>
                                            </tr>
                                        </thead>
                                        @{
                                            if (Model.OrderLines == null)
                                            {
                                                Model.OrderLines = new List<Account.Models.OrderLines>();
                                                Account.Models.OrderLines Line = new Account.Models.OrderLines();
                                                Line.CustomerID = Model.CustomerID;
                                                Model.OrderLines.Add(Line);
                                            }
                                            foreach (var item in Model.OrderLines)
                                            {
                                                Html.RenderPartial("orderline", item);
                                            }
                                        }
                                    </table>

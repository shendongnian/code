      @foreach (var item in ViewBag.ItemId)
                    {
                        if(item.someCheck)
                        {
                          <option value="@(item.Text + "---- " + item.Value)">
                          </ option >
                         }
                    }

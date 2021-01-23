            @foreach (var item in ViewBag.ItemId)
            {
                  string stock = item.Text.Split('(',')')[1];
                  if(!stock.Equals("0"))
                 {
                      <option value="@(item.Text + "---- " + item.Value)"></ option >
                 }
            }

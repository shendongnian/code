    foreach (var prices in priceTags)
    {
       label9.Visible = true;
       label9.Text += prices.InnerHtml + "\n";
       productPriceList.Add(Decimal.Parse(prices.InnerHtml, <cultureInfoHere>));
       label2.Visible = false;
       label3.Visible = false;
    }

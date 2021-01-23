    private void button1_Click(object sender, EventArgs e) {
       RemoveLastTotal();
       AppendPrices();
       AppendTotal();
    }
    
    private void RemoveLastTotal() {
       var lastItemIndex = listBox2.Items.Count-1;
       if (listBox2.Items[lastItemIndex].StartsWith("Total Price:"))
       {
           listBox2.Items.RemoveAt(lastItemIndex);
       }
    }
    
    private void AppendPrices() {
        string TheItem = Convert.ToString(listBox1.SelectedItem);
        string[] theSplits = TheItem.Split(' ');
        string itemDesc = theSplits[0];
        string itemPrice = theSplits[1];
        float quantity = (string.IsNullOrEmpty(textBox1.Text))? 0: float.Parse(textBox1.Text)
 
        if (quantity==0) {
           listBox2.Items.Add(TheItem);
        } else {
          var lineTotal = Convert.ToDecimal(itemPrice) * quantity;
          listBox2.Items.Add(textBox1.Text + " x " + TheItem + " = " + lineTotal);
       }        
    }
    private void AppendTotal()
    {
        var total = 0;
        foreach(var item in listBox2.Items)
        {
          var splits = item.Split(' ');
          total += decimal.parse(splits[splits.length-1]);
        }
        listBox2.Items.Add("Total Price:" + total);               
    }

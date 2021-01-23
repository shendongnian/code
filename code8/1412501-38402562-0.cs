    // ReadAllLines already returns your text file splitted at newlines
    string[] aa = File.ReadAllLines(@"order/1.dll");
    // With lists you don't need to create a fixed size array in advance...
    List<string> orders = new List<string>();
    List<string> carts = new List<string>();
    // Your array could be iterated two items at times 
    // Of course here a check for even number of items should be
    // added here....
    for (int i = 0; i < aa.Length; i += 2)
    {
         orders.Add(aa[i]);
         carts.Add(aa[i+1]);
    }
    // The collections have the possibility to add a range of items
    // without you writing a loop 
    AddToCartList.Items.AddRange(carts.ToArray());
    OrderIDList.Items.AddRange(orders.ToArray());

    public class ItemProperties
    {
        public string Item { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public string Tax { get; set; }
        public int TotalPay
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }
    }
        var lines = File.ReadAllLines(openFileDialog.FileName);
        for (var i = 9; i + 2 < lines.Length; i += 6)
            {
                Items.Add(new ItemProperties
                {
                    Item = lines[i],
                    Description = lines[i + 1],
                    Quantity =  Convert.ToInt32(lines[i + 2]),
                    UnitPrice = Convert.ToInt32(lines[i + 3]),
                    Tax = lines[i + 4]
                });
            }
            itemlst.ItemsSource = Items;

    public class Order 
    {
       public int NumberOfItems {get; set;}
       public double Price {get; set;}
    }
    comboBox1.ItemsSource = new List<Order>
    {
        new Order { NumberOfItems = 1, Price = 20 }
        new Order { NumberOfItems = 2, Price = 40 }
    }

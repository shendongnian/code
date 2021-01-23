    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Samples
    {
        static class Program
        {
            static void ReducePrice(DataGridView productView, decimal percentage)
            {
                var factor = 1 - percentage / 100;
                var data = (List<Product>)productView.DataSource;
                Parallel.For(0, data.Count, index =>
                {
                    var product = data[index];
                    product.Price = (double)((decimal)product.Price * factor);
                });
                productView.Refresh();
            }
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var form = new Form();
                var dg = new DataGridView { Dock = DockStyle.Fill, Parent = form };
                dg.DataSource = GetProductList();
                var button = new Button { Dock = DockStyle.Bottom, Parent = form, Text = "Reduce Price by 20%" };
                button.Click += (sender, e) => ReducePrice(dg, 20);
                Application.Run(form);
            }
            static List<Product> GetProductList()
            {
                var random = new Random();
                return Enumerable.Range(1, 1000000).Select(n => new Product { ID = n, Name = "Product#" + n, Price = random.Next(10, 1000) }).ToList();
            }
        }
        public class Product
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
        }
    }

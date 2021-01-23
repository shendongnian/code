     public class EmployeList : IItemsSource
    {
        public Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ItemCollection GetValues()
        {
            Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ItemCollection employe = new Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ItemCollection();
            employe.Add(new Employe()
            {
                Name = "Name1",
                Rank = "Rank1",
                Age=40,
            }); employe.Add(new Employe()
            {
                Name = "Name2",
                Rank = "Rank2",
                Age=40,
            }); employe.Add(new Employe()
            {
                Name = "Name3",
                Rank = "Rank3",
                Age=40,
            });
            return employe;
        }
    }

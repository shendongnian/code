    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    
    namespace WpfApplication1
    {
        public class ViewModel : INotifyPropertyChanged
        {
            private ObservableCollection<INode> families;
            public ObservableCollection<INode> Families
            {
                get { return families; }
                set
                {
                    families = value;
                    NotifyPropertyChanged("Families");
                }
            }
    
            public ViewModel()
            {
                // FAMILIES
                Families = new ObservableCollection<INode>();
    
                Family family1 = new Family() { Name = "The Doe's" };
                family1.Members.Add(new FamilyMember() { Name = "John Doe", Age = 42 });
                family1.Members.Add(new FamilyMember() { Name = "Jane Doe", Age = 39 });
                family1.Members.Add(new FamilyMember() { Name = "Sammy Doe", Age = 13 });
                Families.Add(family1);
    
                Family family2 = new Family() { Name = "The Moe's" };
                family2.Members.Add(new FamilyMember() { Name = "Mark Moe", Age = 31 });
                family2.Members.Add(new FamilyMember() { Name = "Norma Moe", Age = 28 });
                Families.Add(family2);
    
                Family family3 = new Family() { Name = "The Dunkin's" };
                family3.Members.Add(new FamilyMember() { Name = "Kevin Dunkin", Age = 31 });
                family3.Members.Add(new FamilyMember() { Name = "Breana Dunkin", Age = 28 });
                family2.Members.Add(family3);
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
        public interface INode
        {
            string Name { get; }
        }
    
        public class Family : INode
        {
            public Family()
            {
                this.Members = new ObservableCollection<INode>();
            }
    
            public string Name { get; set; }
            public ObservableCollection<INode> Members { get; set; }
            public Family Parent { get; private set; }
        }
    
        public class FamilyMember : INode
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }

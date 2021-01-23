    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    namespace UnrelatedTests
    {
        [Serializable()]
        public  class MyItem 
        {
           public string ButtonText { get; set; }
           public ImageSource Imagepath { get; set; }
        }
        public partial class UserControl1 : UserControl
        {
            public UserControl1()
            {
                InitializeComponent();
                this.DataContext = this;
            }
            private ObservableCollection<MyItem> _items = new ObservableCollection<MyItem>();
            [Description("Items in sidebar")]
            [Category("Data")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public ObservableCollection<MyItem> Items
            {
                get { return _items; }
            }
        }
    }

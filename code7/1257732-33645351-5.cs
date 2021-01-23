    using System;
    using System.Collections.Generic;
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
    using System.Windows.Shapes;
     
    namespace Learn.MVVM.Example.Views
    {
        /// <summary>
        /// Логика взаимодействия для PersonsView.xaml
        /// </summary>
        public partial class PersonsView: IView
        {
            public PersonsView()
            {
                InitializeComponent();
            }
     
            public void ShowView()
            {
                this.Show();
            }
     
            public void ShowViewAsModal()
            {
                this.ShowDialog();
            }
     
            public void SetDataContext(object dataContext)
            {
                this.DataContext = dataContext;
            }
        }
    }

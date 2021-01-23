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
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace CreateClassesObjs
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
    
            Course choice;
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                Course course1 = new Course("IT 145");
                Course course2 = new Course("IT 200");
                Course course3 = new Course("IT 201");
                Course course4 = new Course("IT 270");
                Course course5 = new Course("IT 315");
                Course course6 = new Course("IT 328");
                Course course7 = new Course("IT 330");
    
                course1.setName("IT 145");
                course2.setName("IT 200");
                course3.setName("IT 201");
                course4.setName("IT 270");
                course5.setName("IT 315");
                course6.setName("IT 328");
                course7.setName("IT 330");
    
                this.comboBox.Items.Add(course1);
                this.comboBox.Items.Add(course2);
                this.comboBox.Items.Add(course3);
                this.comboBox.Items.Add(course4);
                this.comboBox.Items.Add(course5);
                this.comboBox.Items.Add(course6);
                this.comboBox.Items.Add(course7);
            }
    
            private void button_Click(object sender, RoutedEventArgs e)
            {
                choice = (Course)(this.comboBox.SelectedItem);
                this.listBox.Items.Add(choice);
            }
         
            class Course
            {
                private string name = "";
                
    
                public Course(string name)
                {
                    this.name = name;
                }
    
                public void setName(string name)
                {
                    this.name = name;
                }
    
                public string getName()
                {
                    return name;
                }
    
                public override string ToString()
                {
                    return getName();
                }
            }
        }
    }

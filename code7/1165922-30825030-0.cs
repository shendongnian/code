    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                Featured.Click += new EventHandler(Button_Download_Click);
                button2.Click += new EventHandler(Button_Download_Click);
                button3.Click += new EventHandler(Button_Download_Click);
            }
            string XML =
                "<Root>\n" +
                "<TabItem Name=\"tabFeatured\" Header=\"Featured\" DataContext=\"{Binding TemplatesFeatured}\">\n" +
                   "<ScrollViewer>\n" +
                       "<ItemsControl Name=\"ItemsControlFeatured\" ItemsSource=\"{Binding}\">\n" +
                            "<ItemsControl.ItemsPanel>\n" +
                                 "<ItemsPanelTemplate>\n" +
                                      "<WrapPanel/>\n" +
                                 "</ItemsPanelTemplate>\n" +
                            "</ItemsControl.ItemsPanel>\n" +
                            "<ItemsControl.ItemTemplate>\n" +
                               "<DataTemplate>\n" +
                                  "<Button Name=\"Featured\" Tag=\"{Binding Id}\" Click=\"Button_Download_Click\"></Button>\n" +
                               "</DataTemplate>\n" +
                            "</ItemsControl.ItemTemplate>\n" +
                       "</ItemsControl>\n" +
                    "</ScrollViewer>\n" +
                "</TabItem>\n" +
                "<TabItem Name=\"tabFeatured\" Header=\"Featured\" DataContext=\"{Binding TemplatesFeatured}\">\n" +
                   "<ScrollViewer>\n" +
                       "<ItemsControl Name=\"ItemsControlFeatured\" ItemsSource=\"{Binding}\">\n" +
                            "<ItemsControl.ItemsPanel>\n" +
                                 "<ItemsPanelTemplate>\n" +
                                      "<WrapPanel/>\n" +
                                 "</ItemsPanelTemplate>\n" +
                            "</ItemsControl.ItemsPanel>\n" +
                            "<ItemsControl.ItemTemplate>\n" +
                               "<DataTemplate>\n" +
                                  "<Button Name=\"xxxx\" Tag=\"{Binding Id}\" Click=\"Button_Download_Click\"></Button>\n" +
                               "</DataTemplate>\n" +
                            "</ItemsControl.ItemTemplate>\n" +
                       "</ItemsControl>\n" +
                    "</ScrollViewer>\n" +
                "</TabItem>\n" +
                "</Root>\n";
            private void Button_Download_Click(object sender, EventArgs e)
            {
                var button = sender as Button;
                string buttonName = button.Name;
                XDocument doc = XDocument.Parse(XML);
                List<XElement> TabItems = doc.Descendants("TabItem").ToList();
                var xmlButton = TabItems.Select(x => x).Where(y => y.Descendants("Button").FirstOrDefault().Attribute("Name").Value == buttonName).FirstOrDefault().Attribute("Name").Value;
            }
        }
    }
    ​

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
    
    namespace CSC470_Lab6
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            int startingIndex = 0;
            string[] states = new string[] { "AL", "FL", "GA", "KY", "MI", "NC", "SC", "TN", "WV", "VA" };
            Package theCurrentPackage;
            Controller controller = new Controller();
            List<Package> newList = new List<Package>();
            public int zipcode;
            public MainWindow()
            {
                InitializeComponent();
                PkgsByStateCmbo.ItemsSource = states;
                controller.initMasterList();
                for (int i = 0; i < controller.allPackages.Count; i++)
                {
                    List<Package> lst = controller.allPackages[i];
                    lst.Clear();
                }
                
               
                
            }
            
    
            private void ScanBtn_Click(object sender, RoutedEventArgs e)
            {
                ArrivedAtTxtBlk.IsEnabled = true;
                theCurrentPackage = new Package();
                PkgIdBlk.IsEnabled = true;
                controller.setInitId();
                controller.getInitId();
                PkgIdBlk.Text = controller.getInitId().ToString();
                theCurrentPackage.Id = controller.getInitId().ToString();
                setPackageAddress();
                setCity();
                setState();
                setZip();
                AddBtn.IsEnabled = true;
                ErrorViewer.IsEnabled = true;
                ScanBtn.IsEnabled = false;
                DateTime time = DateTime.Now;
                ArrivedAtTxtBlk.Text = time.ToString();
            }
            public int getZip()
            {
                zipcode = int.Parse(ZipTxt.Text);
                return zipcode;
            }
            public void setZip()
            {
                ZipTxt.Text = "";
                ZipTxt.IsEnabled = true;
            }
            public string getState()
            {
                int index;
                index = StateCmbo.SelectedIndex - 1;
                if (index >= 0)
                    return states[index];
                else
                    return "NVS";
            }
            public void setState()
            {
               
                StateCmbo.IsEnabled = true;
            }
            public void setCity()
            {
                CityTxt.Text = "";
                CityTxt.IsEnabled = true;
            }
            public string getCity()
            {
                return CityTxt.Text;
            }
            public void setPackageAddress()
            {
                AddressTxt.Text = "";
                AddressTxt.IsEnabled = true;
    
            }
            public string getPackageAddress()
            {
                return AddressTxt.Text;
    
            }
    
    
            private void AddBtn_Click(object sender, RoutedEventArgs e)
            {
                ScanBtn.IsEnabled = false;
    
                bool addr = checkAddress();
                bool cty = checkCity();
                bool ckst = checkState();
                bool chdz = checkZip();
                if((addr == true)&&(cty == true)&&(ckst == true)&&(chdz == true))
                
                {
                    theCurrentPackage.address = getPackageAddress();
                    theCurrentPackage.city = getCity();
                    theCurrentPackage.zip = getZip();
                    theCurrentPackage.state = getState();
                    ErrorViewer.Content = "Package added";
                    int index = StateCmbo.SelectedIndex - 1;
                    controller.allPackages[index].Add(theCurrentPackage);
                    //newList.Add(theCurrentPackage);
                    //theCurrentPackage = null;
                    AddressTxt.Text = "";
                    PkgIdBlk.Text = "";
                    CityTxt.Text = "";
                    ZipTxt.Text = "";
                    ScanBtn.IsEnabled = true;
                    StateCmbo.SelectedIndex = -1;
                    StateCmbo.IsEnabled = false;
                    PkgsByStateCmbo.IsEnabled = true;
                    NextBtn.IsEnabled = true;
                    BackBtn.IsEnabled = true;
                    
                }
               else
                {
                    
                    ErrorViewer.Content = "Package add unsuccessful. Please check for errors and try again";
                    PkgIdBlk.Text = "";
                    AddressTxt.Text = "";
                    CityTxt.Text = "";
                    StateCmbo.SelectedIndex = -1;
                    ZipTxt.Text = "";
                    AddBtn.IsEnabled = false;
                    ScanBtn.IsEnabled = true;
                    theCurrentPackage = null;
                    
                }
                
            }
    
            public bool checkState()
            {
                bool result = false;
                if (getState() != "NVS")
                {
                    result = true;
                }
                return result;
            }
    
            public bool checkAddress()
            {
                bool result = false;
                string str = getPackageAddress();
                if (str != null)
                    result = true;
                return result;
            }
    
            public bool checkCity()
            {
                bool result = false;
                string str = getCity();
                if (str != null)
                    result = true;
                return result;
            }
    
            public bool checkZip()
            {
                bool result = false;
    
                char[] zip = zipcode.ToString().ToCharArray();
                for (int i = 0; i < zip.Length; i++)
                {
                    int val = (int)Char.GetNumericValue(zip[i]);
                    
                    if ((val.Equals(0)) || (val.Equals(1)) || (val.Equals(2)) || (val.Equals(3)) || (val.Equals(4))|| (val.Equals(5)) || (val.Equals(6))|| (val.Equals(7))|| (val.Equals(8)) || (val.Equals(9)))
                    {
    
                        result = true;
                        //return result;
                    }
                    else
                    {
                        result = false;
                    }
                }
                return result;
            }
    
            
            
            private void NextBtn_Click(object sender, RoutedEventArgs e)
            {
                if (startingIndex < newList.Count)
                {
                    startingIndex++;
                    AddressTxt.Text = newList[startingIndex].address;
                    CityTxt.Text = newList[startingIndex].city;
                    //string str = newList[startingIndex].state;
                    //for (int i = 0; i < states.Length; i++)
                    //{
                    //    if (states[i] == str)
                    //    {
                    //        StateCmbo.SelectedIndex = i;
                    //    }
                    //}
                    ZipTxt.Text = newList[startingIndex].zip.ToString();
                }
                else if(startingIndex >= newList.Count)
                {
                    AddressTxt.Text = newList.Last().address;
                    CityTxt.Text = newList.Last().city;
                    string str = newList.Last().state;
                    for (int i = 0; i < states.Length; i++)
                    {
                        if (states[i] == str)
                        {
                            StateCmbo.SelectedIndex = i + 1;
                        }
                    }
                    ZipTxt.Text = newList.Last().zip.ToString();
                }
                
    
            }
    
            private void PkgsByStateCmbo_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                ByStateListBox.Items.Clear();
                if (PkgsByStateCmbo.SelectedIndex >= 0)
                {
                    int selectionI = PkgsByStateCmbo.SelectedIndex;
                    newList = controller.allPackages[selectionI];
                    foreach (Package p in newList)
                    {
                        if (p.state == PkgsByStateCmbo.SelectedItem)
                        {
                            ByStateListBox.Items.Add(p.Id.ToString());
                        }
                    }
                }
    
            } 
           
    
            
        }           
    }

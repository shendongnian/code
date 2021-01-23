    public MainWindow()
            {
                InitializeComponent();
                BindDataToDataGrid();
            }
    
    
            private void Send_Click_1(object sender, RoutedEventArgs e)
            {
    
            }
    
            private void Resend_Click_1(object sender, RoutedEventArgs e)
            {
    
            }
    
            private void Report_Click_1(object sender, RoutedEventArgs e)
            {
    
            }
    
            public static T FindVisualParent<T>(UIElement element) where T : UIElement
            {
                UIElement parent = element;
                while (parent != null)
                {
                    T correctlyTyped = parent as T;
                    if (correctlyTyped != null)
                    {
                        return correctlyTyped;
                    }
                    parent = VisualTreeHelper.GetParent(parent) as UIElement;
                }
                return null;
            }
    
            private void BindDataToDataGrid()
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("StatusCode");
                dt.Rows.Add("Kartik", "Send");
                dt.Rows.Add("Ashok", "Resend");
                dt.Rows.Add("Paresh", "Report");
                dt.AcceptChanges();
    
                data1.ItemsSource = dt.DefaultView;
            }
    
            private void data1_PreviewMouseRightButtonDown_1(object sender, MouseButtonEventArgs e)
            {
                if (e.OriginalSource.GetType() != typeof(DataGridColumnHeader))
                {
                    DataGridRow dgr = FindVisualParent<DataGridRow>(e.OriginalSource as UIElement);
                    if (dgr != null && dgr.Item != null)
                    {
                        //here checked value of statuscode on the basis of row clicked
                        string statusCode = Convert.ToString((dgr.Item as DataRowView).Row["StatusCode"]);
    
                        if (statusCode == "Send")
                        {
                            MenuItem objResend = new MenuItem();
                            objResend.Header = "Resend";
                            objResend.Click += Resend_Click_1;
    
                            MenuItem objsend = new MenuItem();
                            objsend.Header= "Send";
                            objsend.IsEnabled = false;
    
                            data1.ContextMenu = new System.Windows.Controls.ContextMenu();
    
                            data1.ContextMenu.Items.Add(objResend);
                            data1.ContextMenu.Items.Add(objsend);
                        }
                        else if (statusCode == "Resend")
                        {
                            //on resend resend is disabled
                            MenuItem objResend = new MenuItem();
                            objResend.Header = "Resend";
                            objResend.IsEnabled = false;
                            
                            MenuItem objsend = new MenuItem();
                            objsend.Header = "Send";
                            objsend.Click += Send_Click_1;
                            
                            data1.ContextMenu = new System.Windows.Controls.ContextMenu();
                            data1.ContextMenu.Items.Add(objResend);
                            data1.ContextMenu.Items.Add(objsend);
                        }
                        else if (statusCode == "Report")
                        {
                            //both are enabled 
                            MenuItem objResend = new MenuItem();
                            objResend.Header = "Resend";
                            objResend.Click += Resend_Click_1;
    
                            MenuItem objsend = new MenuItem();
                            objsend.Header = "Send";
                            objsend.Click += Send_Click_1;
    
                            data1.ContextMenu = new System.Windows.Controls.ContextMenu();
                            data1.ContextMenu.Items.Add(objResend);
                            data1.ContextMenu.Items.Add(objsend);
                        }
                    }
                }
            }
